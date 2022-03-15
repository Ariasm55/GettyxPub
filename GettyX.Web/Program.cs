global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
using GettyX.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using GettyX.Web.Services;
using GettyX.Web.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


builder.Services.AddSingleton(new HttpClient()
{ 
    BaseAddress = new Uri("https://localhost:7021/")
});



builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IScheduleServices, ScheduleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();


await builder.Build().RunAsync();
