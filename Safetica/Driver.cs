using System.Net;
using Microsoft.Playwright;

namespace Safetica;

public class Driver: IDisposable
{
    private readonly Task<IPage> _page;
    private IBrowser? _browser;

    public Driver(IBrowserType browser)
    {
        _page = InitializePlaywright(browser);
        
    }
    
    public IPage Page => _page.Result;
    

    private async Task<IPage> InitializePlaywright(IBrowserType browser)
    {
        var browserOption = new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 100
        };
        _browser = await browser.LaunchAsync(browserOption);
        return await _browser.NewPageAsync();
    }

    public void Dispose()
    {
        _browser.CloseAsync();
    }

    public TaskStatus GetStatus()
    {
        return _page.Status;
    }
}