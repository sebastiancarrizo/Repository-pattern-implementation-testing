using Microsoft.EntityFrameworkCore;
using Test.Data.Context;
using Test.Data.Models;
using Test.DataAccess.Interfaces;
using Test.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PermissionContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PermissionCS")));
builder.Services.AddScoped<IRepositoryAsync<Permission>, RepositoryAsync<Permission>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
