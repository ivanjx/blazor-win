using Microsoft.JSInterop;

namespace BlazorHybrid.Shared.Services;

public sealed class BrowserInteropService(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask = new(() =>
        jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazorHybrid.Shared/js/blazorInterop.js").AsTask());

    public async ValueTask<int> AddAsync(int left, int right)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<int>("addNumbers", left, right);
    }

    public async ValueTask<string> SayHelloAsync(string name)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("sayHello", name);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
