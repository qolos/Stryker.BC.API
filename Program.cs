//using System;
//using System.Reflection;
using Asp.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

using Stryker.BC.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfigurer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("swagger/v1.0", new OpenApiInfo { Title = "Stryker.BC.API", Version = "v1.0" });     // NOTE: ApiVersion change here
    c.SwaggerDoc("swagger/v1.1", new OpenApiInfo { Title = "Stryker.BC.API", Version = "v1.1" });   // NOTE: ApiVersion change here v1.1 
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
});

var apiver = builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 1);           // NOTE: ApiVersion change here v1.1 
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

apiver.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();

            foreach (var description in descriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        });
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();   // All Controllers become WebApi end points

app.Run();

