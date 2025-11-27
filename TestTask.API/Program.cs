using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.App.Interfaces;
using TestTask.App.MappingProfiles;
using TestTask.App.Services;
using TestTask.Data;
using TestTask.Data.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestTaskSystemDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddExpressionMapping();

}, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarStorage, CarStorage>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
