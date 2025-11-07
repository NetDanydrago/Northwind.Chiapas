using CategoryManager.Proxy;
using CategoryManager.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Northwind.Web;
using ProductManager.Proxy;
using ProductManager.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddCategoryManagerViewModels();
builder.Services.AddCategoryManagerProxies(proxy =>
{
    proxy.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
});
builder.Services.AddProductManagerViewModels();
builder.Services.AddProductManagerProxies(proxy =>
{
    proxy.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]);
});
await builder.Build().RunAsync();
