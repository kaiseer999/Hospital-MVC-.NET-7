using bloodyvalentinee;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using bloodyvalentinee.Models.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AplicacionDBContext>(opciones => 
opciones.UseSqlServer("name = conexionDefault "));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Acceso/Index";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.AccessDeniedPath = "/Home/Privacy";
    });





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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");










app.Run();
