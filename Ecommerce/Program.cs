using Ecommerce_DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using RouteJs;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Ecommerce_DataAcess.Repository.IRepository;
using Ecommerce_DataAcess.Repository;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

/*builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddRouteJs();

builder.Services.AddRouteJs(config => {
    config.ExposeAllRoutes = true;
});

builder.Services.AddReact();

builder.Services.AddJsEngineSwitcher(options=>options.DefaultEngineName= V8JsEngine.EngineName).AddV8();*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
/*
app.UseReact(config => 
{

});*/

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
