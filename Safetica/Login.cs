using Microsoft.Playwright;

namespace Safetica;

public class Login(IPage page)
{
    
    private readonly ILocator _emailInput = page.Locator("//input[@name='loginfmt']");
    private readonly ILocator _passwordInput = page.Locator("//input[@name='passwd']");
    private readonly ILocator _submitButton = page.Locator("//input[@type='submit']");
    private readonly ILocator _dontKeepMeLoggedInButton = page.Locator("//input[@id='idBtn_Back']");

    public async Task LogMeIn(string username, string password)
    {
        await _emailInput.FillAsync(username);
        await _submitButton.ClickAsync();
        await _passwordInput.FillAsync(password);
        await _submitButton.ClickAsync();
        await _dontKeepMeLoggedInButton.ClickAsync();
    }
}