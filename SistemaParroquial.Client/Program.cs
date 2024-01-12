using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SistemaParroquial.Client;
using SistemaParroquial.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5052") });

//Add-services
builder.Services.AddScoped<IMisaTipoService, MisaTipoService>();
builder.Services.AddScoped<IMisaMotivoService, MisaMotivoService>();
builder.Services.AddScoped<IMisaRootService, MisaRootService>();
builder.Services.AddScoped<INombresRootService, NombresRootService>();

await builder.Build().RunAsync();
