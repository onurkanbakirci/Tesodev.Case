var builder = WebApplication.CreateBuilder(args);


builder.Host
    .ConfigureAppConfiguration((context,config) =>
    {
        config
            .SetBasePath(context.HostingEnvironment.ContentRootPath)
            .AddJsonFile("Configurations/ocelot.json")
            .AddEnvironmentVariables();
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddOcelot();

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOcelot().Wait();

app.MapControllers();

app.Run();