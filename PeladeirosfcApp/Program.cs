using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Data;
using PeladeirosfcApp.Services;
using PeladeirosfcApp.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

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
                "https://localhost:7002",  // Blazor WebAssembly HTTPS
                "http://localhost:5002"     // Blazor WebAssembly HTTP
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
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

// Opcional: definir política de referrer explicitamente
app.Use(async (context, next) =>
{
    context.Response.Headers["Referrer-Policy"] = "no-referrer";
    await next();
});

app.UseHttpsRedirection();

// Aplicar CORS antes de MapControllers
app.UseCors("AllowLocalDev");

app.UseAuthorization();

app.MapControllers();

app.Run();
