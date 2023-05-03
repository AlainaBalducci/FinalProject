using Microsoft.EntityFrameworkCore;
using RestaurantApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = "server=localhost;user= restaurant_api;password=restaurant_api;database=restaurants_api";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<RestaurantDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

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
