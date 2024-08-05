using library_automation.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
// Load environment variables from .env file
Env.Load();
// Add services to the container.
builder.Services.AddControllersWithViews();

// Retrieve user and password from environment variables
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString = builder.Configuration.GetConnectionString("Default")
    .Replace("{DB_USER}", dbUser)
    .Replace("{DB_PASSWORD}", dbPassword);
// Add Database Connectivity
builder.Services.AddDbContext<dbContext>(options =>
options.UseSqlServer(connectionString));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
