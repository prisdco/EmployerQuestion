using Application.DependencyInjection;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using ServiceModel.Entities;
using ServiceModel.Model;
using System.Collections;
using System.Configuration;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().Enrich.FromLogContext().ReadFrom.Configuration(ctx.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddApplicationPrograms(builder.Configuration);
builder.Services.AddSwaggerGen();


// Load the Cosmos DB account settings from app settings
var cosmosSettings = builder.Configuration.GetSection("CosmoDbSetting");

builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    var options = new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway };
    return new CosmosClient(cosmosSettings["EndPointUrl"], cosmosSettings["PrimaryKey"], options);
});


builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ApiVersionReader = new UrlSegmentApiVersionReader();
})
    .AddMvc()
.AddApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddCors(c =>
{
    c.AddPolicy("QuestionProgramPortalPolicy", corspolicy =>
    {
        corspolicy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI();
app.UseExceptionHandler("/error");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }