using Microsoft.Playwright;

namespace Safetica;

public class CommonTest
{
    private readonly string _name;

    protected CommonTest(string name)
    {
        _name = name;
        Setup();
    }

    private void Setup()
    {
        Logger.Log("Starting test " + _name);

    }

    protected static void TearDown(TaskStatus status)
    {
        Logger.Log("Ending test");
        Logger.Log(status.ToString());
        Logger.LogNewLine();
    }
}