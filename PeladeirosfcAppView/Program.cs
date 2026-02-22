using Microsoft.AspNetCore.Components.Authorization;    
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeladeirosfcAppView;
using PeladeirosfcAppView.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient: ApiBaseUrl em appsettings (ex.: http://localhost:5112) ou mesma origem
var baseAddress = builder.HostEnvironment.BaseAddress;
var apiBase = builder.Configuration["ApiBaseUrl"]?.TrimEnd('/');
if (!string.IsNullOrEmpty(apiBase))
    baseAddress = apiBase + "/";
else
    baseAddress = baseAddress.TrimEnd('/') + "/";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

// Registrar serviços da API
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar autenticação e autorização
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();
