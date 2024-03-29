using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System;
using VegApp;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VegAppContextConnection") ?? throw new InvalidOperationException("Connection string 'VegAppContextConnection' not found.");

builder.Services.AddDbContext<VegAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<VegAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<VegAppContext>();




// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddScoped<UserProvider>();
builder.Services.AddScoped<PersonalizedRecommendation>();
var app = builder.Build();

using var scope = app.Services.CreateScope();
var vegAppContext = scope.ServiceProvider.GetService<VegAppContext>();
var productImporter = new ProductImporter(vegAppContext);
productImporter.ImportProduct();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();


    app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
