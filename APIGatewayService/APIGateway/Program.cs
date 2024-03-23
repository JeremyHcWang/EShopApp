using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
// go to root folder to find ocelot.json file and run it in Program.cs
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true).AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
    
var app = builder.Build();

await app.UseOcelot();

app.Run();