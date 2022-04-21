using Microsoft.EntityFrameworkCore;
using mvcapp.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllersWithViews();

string constr = string.Empty;

if (environment.IsDevelopment())
{
    constr = configuration.GetConnectionString("DB_CONNECTION_STRING");
}
else
{
    constr = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? 
        throw new ArgumentNullException("[DB_CONNECTION_STRING] should be in Environment variables");
}

builder.Services.AddDbContext<ApiDbContext>(options => options.UseNpgsql(constr));

var app = builder.Build();

var db = app.Services.GetRequiredService<ApiDbContext>();
db.Database.Migrate();

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
