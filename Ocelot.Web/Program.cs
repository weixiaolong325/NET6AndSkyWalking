using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SkyApm.Utilities.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);//ocelot
builder.Services.AddSkyApmExtensions(); // ÃÌº”Skywalkingœ‡πÿ≈‰÷√

builder.Services.AddOcelot(); //ocelot
var app = builder.Build();


app.UseOcelot().Wait(); //ocelot

app.Run();
