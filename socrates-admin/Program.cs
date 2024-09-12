using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using socrates_admin;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAntDesign();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8888") });

await builder.Build().RunAsync();
