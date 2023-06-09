using Microsoft.EntityFrameworkCore;
//using Kapow.Data;
using Microsoft.AspNetCore.Identity;
using Kapow.Data;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ProfileDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ProfileDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "server=localhost;user=kapow;password=kapow;database=kapow";

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<ProfileDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ProfileDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>
(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 10;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ProfileDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=profile}/{action=Index}/{id?}");

app.Run();
