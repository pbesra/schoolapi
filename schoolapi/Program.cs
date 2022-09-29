using FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;
using schoolapi.Application.Services.Student;
using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Extensions.ServiceDI;
using schoolapi.Infrasctructure;
using schoolapi.Infrasctructure.DatabaseLayer.DbConfig;
using schoolapi.Infrasctructure.DatabaseLayer.Repositories.Student;
using schoolapi.Service.Implemetations;
using schoolapi.Service.Interfaces;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Program>())
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
        });
string _originPolicy = "SameOriginPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        _originPolicy,
        builder =>
        {
            builder.WithOrigins("*")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.ServiceInjection();

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
/*builder.Services.AddSwaggerGen();*/
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault().DisplayName);
});

var app = builder.Build();

app.Configuration.DbMigration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_originPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();