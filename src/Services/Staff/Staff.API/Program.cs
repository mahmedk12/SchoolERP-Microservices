using Staff.API.Extensions;
using Staff.Infrastructure.Persistence;
using Staff.Application;
using Staff.Infrastructure;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Api Versioning
// Add API Versioning to the Project
builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
})
// Add ApiExplorer to discover versions
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
#endregion

//disable builtin Badrequest reponse to show our custom response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfraStructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
#region Swagger Configuration

builder.Services.AddSwaggerGen(c =>
{
    // top level
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Braincrop School_ERP Staff Service Rest API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "BrainCrop",
            Url = new Uri("https://braincrop.net")
        }
    });




    // security header
    //c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    //{
    //    Description = "Token Authorization header using the ApiKey scheme",
    //    Type = SecuritySchemeType.ApiKey,
    //    In = ParameterLocation.Header,
    //    Name = "X-Api-Key"
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "ApiKey"
    //            }
    //        },
    //        new string[] {}
    //    }
    //});

    //enable Annoation required for documentation purposes
    c.EnableAnnotations();


});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
        c.DefaultModelsExpandDepth(-1);//to disbale All Models
        //c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase<StaffDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<StaffDbContextSeed>>();
    StaffDbContextSeed.SeedAsync(context,logger).Wait();
});
app.Run();
