using EsportsPortal.WebApi.Clients;
using EsportsPortal.WebUi;
using EsportsPortal.WebUi.Authentication;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddFluentUIComponents();

builder.Configuration.AddJsonFile("appsettings.json", optional: false);

builder.Services.AddApiClients(builder.Configuration);
builder.Services.AddSingleton<DataSource>();

builder.Services.AddUsersAuthentication();

await builder.Build().RunAsync();
