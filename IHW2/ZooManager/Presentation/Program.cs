using System.Reflection;
using Microsoft.OpenApi.Models;
using ZooManager.Application;
using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.Utils;
using ZooManager.Domain.ValueObjects.AnimalValueObjects;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;
using ZooManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
});;
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton(new Dictionary<Guid, Animal>());
builder.Services.AddSingleton(new Dictionary<Guid, Enclosure>());
builder.Services.AddSingleton(new Dictionary<FeedingScheduleId, FeedingSchedule>());

builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<EnclosureService>();
builder.Services.AddScoped<AnimalTransferService>();
builder.Services.AddScoped<FeedingOrganizationService>();
builder.Services.AddScoped<ZooStatisticsService>();
builder.Services.AddScoped<IAnimalStorage, InMemoryAnimalStorage>();
builder.Services.AddScoped<IEnclosureStorage, InMemoryEnclosureStorage>();
builder.Services.AddScoped<IFeedingScheduleStorage, InMemoryFeedingScheduleStorage>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();