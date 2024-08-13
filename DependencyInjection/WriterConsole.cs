using System;

namespace Dotnet.DependencyInjection;

public class WriterConsole : IWriter
{
    public bool IsEnabled { get; set; } = true;
    void IWriter.WriteLine(string name)
    {
        if (IsEnabled)
            Console.WriteLine(name);
    }
}
