using Microsoft.EntityFrameworkCore;
using Nimbus.Shared;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
//using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nimbus API", Version = "v1" });
//});
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nimbus API v1"));
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
