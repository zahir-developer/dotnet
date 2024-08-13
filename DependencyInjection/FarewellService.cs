using System;

namespace Dotnet.DependencyInjection;

public class FarewellService(IWriter writer)
{
    public string SayGoodbye(string name)
    {
        var farewell = $"Goodbye, {name}!";

        writer.WriteLine(farewell);

        return farewell;
    }
}
