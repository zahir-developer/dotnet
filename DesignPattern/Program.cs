var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    string urls = string.Empty;
    urls += "/FactoryMethod\n";
    urls += "/AbstractFactory\n";
    return urls;
});

var services = new ServiceCollection();
//Factory method
services.AddSingleton<DesignPatterns.FactoryMethod.FactoryMethodExample>();

//Abstract factory
services.AddSingleton<DesignPatterns.AbstractFactory.AbstractFactoryExample>();

//Build services
var serviceProvider = services.BuildServiceProvider();


var factoryMethodService = serviceProvider.GetRequiredService<DesignPatterns.FactoryMethod.FactoryMethodExample>();
var abstractFactoryService = serviceProvider.GetRequiredService<DesignPatterns.AbstractFactory.AbstractFactoryExample>();
app.MapGet("/factoryMethod/", () =>
{
    return factoryMethodService.Run();
});

app.MapGet("/abstractFactory/", () =>
{
    return abstractFactoryService.Run();
});
app.Run();
