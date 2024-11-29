using SBReceiver;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IReceiverService, ReceiverService>();

var serviceProvider = builder.Services.BuildServiceProvider();

var receiver = serviceProvider.GetService<IReceiverService>();

if (receiver == null)
    return;
else
    await receiver.ReceiveMessage();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
