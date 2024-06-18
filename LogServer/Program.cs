var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{

});

var app = builder.Build();

app.MapGet("/", () =>
{
    return "init";
});

app.Run();

