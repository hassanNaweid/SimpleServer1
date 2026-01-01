using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var messages = new List<Message>();
app.MapGet("/", () => "SERVER IS RUNNING");

app.MapPost("/send", (Message msg) =>
{
    messages.Add(msg);
    return Results.Ok(new { status = "ok" });
});

app.MapGet("/receive", () =>
{
    if (messages.Count == 0)
        return Results.Ok(new Message("none", "no messages"));

    return Results.Ok(messages.Last());
});

app.Run();

record Message(string sender, string text);
