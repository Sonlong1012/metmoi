using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Webbanhang_22011267.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("Webdb") ?? throw new InvalidOperationException("Connection string 'IdentityContextConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
builder.Services.AddSession(cfg => {                    // Đăng ký dịch vụ Session
    cfg.Cookie.Name = "Webbanhang_22011267";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
    cfg.IdleTimeout = new TimeSpan(0, 30, 0);    // Thời gian tồn tại của Session
});

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();



//DI for DbContext
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
   name: "admin",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
