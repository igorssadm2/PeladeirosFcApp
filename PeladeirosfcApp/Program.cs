using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Data;
using PeladeirosfcApp.Services;
using PeladeirosfcApp.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// ✅ Forçar HTTP em desenvolvimento
if (builder.Environment.IsDevelopment())
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
                "https://localhost:7109",  // ✅ PORTA DO BLAZOR WASM (HTTPS)
                "http://localhost:5268",   // ✅ PORTA DO BLAZOR WASM (HTTP)
                "https://localhost:44351", // ✅ IIS Express SSL
                "https://localhost:5112",  // API (caso consuma a si mesma)
                "http://localhost:5112"    // API HTTP
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



