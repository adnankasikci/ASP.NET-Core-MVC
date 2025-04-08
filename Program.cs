
using AppSpace.IRepositories;
using AppSpace.Repositories;
using AppSpace.Services;
using Microsoft.EntityFrameworkCore;
using MyAspNetProject.Extensions;
using MyAspNetProject.Namespace;

var builder = WebApplication.CreateBuilder(args);

// -----------------------  Session Service
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AdminActionFilter>();

// -----------------------  JWT Token Service
builder.Services.AddScoped<JwtTokenService>();

// -----------------------  Added
builder.Services.DatabaseConfiguration(builder.Configuration);
builder.Services.JwtAuthentication(builder.Configuration);
builder.Services.SessionManagement();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

// -----------------------  Finished ----------------

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // JWT authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
