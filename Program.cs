using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // front-end origin — não use "*" se usar credenciais
            .AllowAnyHeader()
            .AllowAnyMethod();
            // .AllowCredentials(); // habilite apenas se realmente for necessário e então não use WithOrigins("*")
    });
});

var app = builder.Build();

app.UseRouting();

// Apply CORS policy globalmente - não indicado para produção
//app.UseCors("AllowFrontend");

// Optional: definir Referrer-Policy explicitamente
app.Use(async (context, next) =>
{
    context.Response.Headers["Referrer-Policy"] = "no-referrer"; // ou "strict-origin-when-cross-origin"
    await next();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();