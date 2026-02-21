using Microsoft.AspNetCore.Components.Authorization;    
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeladeirosfcAppView;
using PeladeirosfcAppView.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient para comunicar com a API
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5112/") // Ajuste para a porta da sua API
});

// Registrar servi�os da API
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar autentica��o e autoriza��o
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();
