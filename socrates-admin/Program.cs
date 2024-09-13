using AntDesign;
using Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Services;
using socrates_admin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAntDesign();

builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IPermissionSpaceService, PermissionSpaceService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped(sp =>
{

    var handler = new CustomHttpClientHandler(sp.GetRequiredService<IMessageService>(), sp.GetRequiredService<NavigationManager>())
    {

        InnerHandler = new HttpClientHandler()
    };
    return new HttpClient(handler) { BaseAddress = new Uri("http://localhost:8888") };
});

var host = builder.Build();
await host.RunAsync();
