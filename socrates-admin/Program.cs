using AntDesign;
using Blazored.LocalStorage;
using Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Services;
using socrates_admin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAntDesign();

builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IPermissionSpaceService, PermissionSpaceService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddScoped(sp =>
{

    var handler = new CustomHttpClientHandler(sp.GetRequiredService<IMessageService>(), sp.GetRequiredService<NavigationManager>(), sp.GetRequiredService<ILocalStorageService>())
    {

        InnerHandler = new HttpClientHandler()
    };
    return new HttpClient(handler) { BaseAddress = new Uri("http://localhost:8888") };
});

var host = builder.Build();
await host.RunAsync();
