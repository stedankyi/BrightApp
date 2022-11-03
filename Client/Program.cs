global using BrightApp.Shared;
global using BrightApp.Client.Services.BleetService;
global using Blazored.LocalStorage;
using BrightApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using BrightApp.Client.Services.AuthService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddScoped<IBleetService, BleetService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider , CustomAuthStateProvider>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();