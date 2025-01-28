using Microsoft.Playwright;

namespace Safetica;

public class TeamsFirefoxTest() : CommonTest("TeamsFirefoxTest")
{
    [Test]
    public async Task Test1()
    {
        
        using var playwright = await Playwright.CreateAsync();
        var driver = new Driver(playwright.Firefox);
        var page = driver.Page;
        
        Logger.Log("Going to page");
        await page.GotoAsync($"https://teams.microsoft.com/v2/");
        
        Logger.Log("Attempting Login");
        Login login = new Login(page);
        await login.LogMeIn("qa@safeticaservices.onmicrosoft.com", "automation.Safetica2004");
        
        Logger.Log("Login successful");
        await page.ClickAsync("//span[contains(text(),'Safetica QA')]");
        
        Logger.Log("Attaching files");
        Messenger messenger = new Messenger(page);
        await messenger.AttachCloudFile("PdfFile.pdf");
        await messenger.AttachCloudFile("XlsxFile.xlsx");
        
        Logger.Log("Files attached");
        
        Logger.Log("Sending message");
        await page.WaitForTimeoutAsync(timeout: 1000);
        
        Logger.Log("Sending message");
        await messenger.Send("Hi everyone!");
        await page.WaitForTimeoutAsync(timeout: 1000);
        
        Logger.Log("Sending message");
        await messenger.Send("Hi everyone!");
        await page.WaitForTimeoutAsync(timeout: 1000);
        
        Logger.Log("Sending message");
        await messenger.Send("Hi everyone!");
        await page.WaitForTimeoutAsync(timeout: 1000);

        TearDown(driver.GetStatus());
    }
}