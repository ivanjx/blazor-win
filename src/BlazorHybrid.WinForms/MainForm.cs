using BlazorHybrid.Shared;
using BlazorHybrid.Shared.Services;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHybrid.WinForms;

public sealed class MainForm : Form
{
    public MainForm()
    {
        Text = "Blazor Hybrid";
        Width = 1200;
        Height = 800;

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddScoped<BrowserInteropService>();

#if DEBUG
        services.AddBlazorWebViewDeveloperTools();
#endif

        var blazorWebView = new BlazorWebView
        {
            Dock = DockStyle.Fill,
            HostPage = Path.Combine(AppContext.BaseDirectory, "wwwroot", "index.html"),
            Services = services.BuildServiceProvider()
        };

        blazorWebView.RootComponents.Add<App>("#app");

        Controls.Add(blazorWebView);
    }
}
