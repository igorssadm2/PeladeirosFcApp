using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Data;
using PeladeirosfcApp.Services;
using PeladeirosfcApp.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Em desenvolvimento local (fora do Docker): escuta na 5112. No Docker usa ASPNETCORE_HTTP_PORTS (8080).
if (builder.Environment.IsDevelopment() && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_HTTP_PORTS")))
{
    builder.WebHost.UseUrls("http://localhost:5112");
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalDev", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000",
                "http://localhost:5173",
                "https://localhost:7002",
                "http://localhost:5002",
                "https://localhost:7109",  // Blazor WebAssembly HTTPS
                "http://localhost:5268",   // Blazor WebAssembly HTTP
                "http://localhost:31409",  // Blazor IIS Express
                "https://localhost:44351", // IIS Express SSL
                "https://localhost:5112",
                "http://localhost:5112",
                "http://localhost:8080"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // ✅ Adicione isso se usar autenticação
    });
});

// Configura EF Core com SQLite. Usa a connection string em appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar serviços
builder.Services.AddScoped<IUsuarioService, UsuarioServices>();


var app = builder.Build();

// Aplica migrações automaticamente ao iniciar (útil em desenvolvimento)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowLocalDev");  // ✅ CORS antes de Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();



