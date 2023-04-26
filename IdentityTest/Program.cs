using IdentityTest.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//for entity framework
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConfigurationBinder.GetConnection));
//for identity
builder.Services.AddIdentity<IdentityUser,  IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

// Add services to the container.
var connectionString = "server=localhost;user=registeruser;password=kapow;database=register-user";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

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
