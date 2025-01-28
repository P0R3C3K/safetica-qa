using System.Reflection.Emit;
using Microsoft.Playwright;

namespace Safetica;

public class Messenger(IPage page)
{
    private readonly ILocator _filePopUpButton = page.Locator(
        "//button[contains(@data-tid,'Commands-message-extension-flyout-command')]");
    private readonly ILocator _attachFileOption = page.Locator("//li[contains(@data-tid,'flyout-list-item')]").First;
    private readonly ILocator _attachCloudFileOption = page.Locator("//span[@data-tid='file-attach-from-onedrive']");
    private readonly ILocator _myFilesNavButton = page.FrameLocator("//iframe[@aria-label]")
        .Locator("//li[div[@name='Moje soubory' or @name='My files']]");
    private readonly ILocator _submitAttachedFilesButton = page.FrameLocator("//iframe[@aria-label]")
        .Locator("//button/span[@data-automationid='splitbuttonprimary'][text()='Připojit' or text()='Attach']");
    private readonly ILocator _sendMessageButton = page.Locator("//button[contains(@data-tid,'MessageCommands-send')]");

    public async Task AttachCloudFile(string file)
    {
        await _filePopUpButton.ClickAsync();
        await _attachFileOption.ClickAsync();
        await _attachCloudFileOption.ClickAsync();
        await _myFilesNavButton.ClickAsync();
        var fileLocator = page.FrameLocator("//iframe[@aria-label]").Locator(GetFileSelector(file));
        await fileLocator.ClickAsync();
        await _submitAttachedFilesButton.ClickAsync();
    }
    
    public async Task Send(string? message)
    {
        if (message is not null)
        {
            await page.Keyboard.TypeAsync(message);
            await _sendMessageButton.ClickAsync();
        }
        else
        {
            Logger.Log("Sending message wihtout text");
            await _sendMessageButton.ClickAsync();
        }
    }

    private static string GetFileSelector(string name)
    {
        return "//div[@data-automationid='FieldRenderer-name'][contains(text(),'" + name + "')]";
    }
}