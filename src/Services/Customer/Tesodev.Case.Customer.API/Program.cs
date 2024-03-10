var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModule());
        builder.RegisterModule(new MediatorModule());
    });

builder.Services.AddCustomDbContext(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Register dependency resolvers
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule(),
}, builder.Configuration);

// Add automapper support
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(options =>
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
            var xmlComments = Path.Combine(basePath, fileName);
            options.IncludeXmlComments(xmlComments);
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Tesodev Case - Customer HTTP API",
                Version = "v1",
                Description = "The Customer HTTP API",
            });
        });

// Add api versioning
builder.Services.AddApiVersioning(v =>
{
    v.DefaultApiVersion = new ApiVersion(1, 0);
    v.AssumeDefaultVersionWhenUnspecified = true;
    v.ReportApiVersions = true;
    v.ApiVersionReader = new HeaderApiVersionReader("x-tesodev-customer-service-api-version");
});

var app = builder.Build();

// Seed database
app.Seed().Wait();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseCustomExceptionMiddleware();

app.MapControllers();

app.Run();