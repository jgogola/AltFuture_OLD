global using System.Data;
global using AltFuture.Models;
global using AltFuture.Models.Extensions;
global using AltFuture.Services;

using System.Security.Claims;
using AltFuture.Areas.Competitions.Services;
using AltFutureWeb.Areas.Cryptos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISQLService, SQLService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICryptoPortfolioRepository, CryptoPortfolioRepository>();
builder.Services.AddScoped<ILKCryptoRepository, LKCryptoRepository>();
builder.Services.AddScoped<ICryptoAPIRepository, CryptoAPIRepository>();
builder.Services.AddScoped<ICryptoPriceRepository, CryptoPriceRepository>();

builder.Services.AddScoped<ILKCompetitionTypeRepository, LKCompetitionTypeRepository>();
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<ICompetitionPlayerRepository, CompetitionPlayerRepository>();


builder.Services.AddSession(options =>
{
    //Pulling the value idletimeout from appsettings.json to populate the session's IdleTimeout
    options.IdleTimeout = TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("SessionSettings:IdleTimeout"));
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication("UserAuth_AltFuture").AddCookie("UserAuth_AltFuture", options =>
{
    options.Cookie.Name = "UserAuth_AltFuture";
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CryptoViewPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, new string[] { ((int)User_Roles.Site_Admin).ToString(), ((int)User_Roles.Crypto_View).ToString(), ((int)User_Roles.Crypto_Admin).ToString() }));
    options.AddPolicy("CryptoAdminPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, (((int)User_Roles.Site_Admin).ToString(), (int)User_Roles.Crypto_Admin).ToString()));

    options.AddPolicy("CompetitionPlayerPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, new string[] { ((int)User_Roles.Site_Admin).ToString(), ((int)User_Roles.Competition_Admin).ToString(), ((int)User_Roles.Competition_Player).ToString() }));
    options.AddPolicy("CompetitionAdminPolicy",
        policy => policy.RequireClaim(ClaimTypes.Role, ((int)User_Roles.Site_Admin).ToString(), ((int)User_Roles.Competition_Admin).ToString()));

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

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
