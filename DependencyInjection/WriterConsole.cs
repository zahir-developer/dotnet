using System;

namespace Dotnet.DependencyInjection;

public class WriterConsole : IWriter, IWriterConsole
{
    public bool IsEnabled { get; set; } = true;

    public void WriteLine(string name)
    {
        throw new NotImplementedException();
    }

    void IWriter.WriteLine(string name)
    {
        if (IsEnabled)
            Console.WriteLine(name);
    }
}
