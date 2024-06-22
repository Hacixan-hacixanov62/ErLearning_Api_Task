using FileApload_FluentValidation.Data;
using FileApload_FluentValidation.Helpers;
using FileApload_FluentValidation.Services.Interface;
using FileApload_FluentValidation.Services;
using Microsoft.EntityFrameworkCore;
using System;
using FluentValidation;
using FileApload_FluentValidation.DTOs.Sliders;
using FluentValidation.AspNetCore;
using FileApload_FluentValidation.Injections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


//builder.Services.AddControllers().AddJsonOptions(x =>
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


builder.Services.AddServices();

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
