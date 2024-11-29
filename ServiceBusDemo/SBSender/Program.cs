using SBSender.Components;
using SBSender.Services;
using SBShared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<IQueueService, QueueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var queueService = app.Services.GetService<IQueueService>();

PersonModel person = new ();
person.FirstName = "Zahir";
person.LastName = "Hussain";

//await queueService.SendMessageAsync<PersonModel>(new List<PersonModel> {person}, "serviceBusQueue");

app.Run();
