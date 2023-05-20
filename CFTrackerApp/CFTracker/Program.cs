using CFTracker.Data;
using CFTracker.Models;
using CFTracker.Services;
using CFTrackerServices;
using CFTrackerServices.Data;
using CFTrackerServices.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cFTrackerConnectionString = builder.Configuration.GetConnectionString("CfTrackerDBConnection") ?? throw new InvalidOperationException("Connection string 'CfTrackerDBConnection' not found.");
builder.Services.AddDbContextPool<CFTrackerContext>(options =>
    options.UseSqlServer(cFTrackerConnectionString));

var connectionString = builder.Configuration.GetConnectionString("IdentityDBConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDBConnection' not found.");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserDB>();
builder.Services.AddSingleton<UserInfoViewModel>();
builder.Services.AddSingleton<LungFunctionViewModel>();
builder.Services.AddSingleton<BodyMassIndexViewModel>();
builder.Services.AddSingleton<UserInfo>();
builder.Services.AddSingleton<LungFunction>();
builder.Services.AddSingleton<BodyMassIndex>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
