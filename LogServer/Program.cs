using LColorin;
Logger logger = new Logger();




var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{

});

var app = builder.Build();
app.MapGet("/", (HttpContext context) =>
{
    //logger.Clear();
    logger.Log(context.TraceIdentifier, Marker.Error);


    return logger.GetAll;



});


app.Run();

