using BlazorHybrid.Shared;
using BlazorHybrid.Shared.Services;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Windows.AppNotifications;
using Microsoft.Windows.AppNotifications.Builder;

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
            HostPage = "wwwroot\\index.html",
            Services = services.BuildServiceProvider()
        };

        blazorWebView.RootComponents.Add<App>("#app");

        Controls.Add(blazorWebView);
    }

    protected override async void OnLoad(EventArgs e)
    {
        await Task.Delay(1000);
        var notification = new AppNotificationBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", "9813")
            .AddText("Andrew sent you a picture")
            .AddText("Check this out, The Enchantments in Washington!")
            .BuildNotification();
        AppNotificationManager.Default.Show(notification);
    }
}
