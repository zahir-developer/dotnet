var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    string urls = string.Empty;
    urls += "/FactoryMethod\n";
    urls += "/AbstractFactoryMethod\n";
    return urls;
});

var services = new ServiceCollection();
services.AddSingleton<DesignPatterns.FactoryMethod.FactoryMethodExample>();

var serviceProvider = services.BuildServiceProvider();

var service = serviceProvider.GetRequiredService<DesignPatterns.FactoryMethod.FactoryMethodExample>();

app.MapGet("/FactoryMethod/", () =>
{
    return service.Run();
});

app.Run();
