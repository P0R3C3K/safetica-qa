namespace Safetica;

using System;
using System.IO;

public abstract class Logger
{
    private static readonly string LogFilePath 
        = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/log.txt";

    public static void Log(string message)
    {
        var timestamp = DateTime.Now;
        var logMessage = $"{timestamp:yyyy-MM-dd HH:mm:ss.fff} - {message}";
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }

    public static void LogNewLine()
    {
        File.AppendAllText(LogFilePath,  Environment.NewLine);
    }
}