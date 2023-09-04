using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanLyNhaHang.Models;

var builder = WebApplication.CreateBuilder(args);

//Thêm chuối kết nối với Database
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
     name: "Product",
     pattern: "product/",
     new { Controller = "Home", Action = "Product"}
   );
    endpoints.MapControllerRoute(
     name: "Menu",
     pattern: "foods/",
     new { Controller = "Home", Action = "Menu" }
   );
    endpoints.MapControllerRoute(
     name: "Contact",
     pattern: "contact/",
     new { Controller = "Home", Action = "Contact" }
   );
    endpoints.MapControllerRoute(
     name: "Employees",
     pattern: "employee/",
     new { Controller = "Home", Action = "Employee" }
   );
    endpoints.MapControllerRoute(
     name: "Booking",
     pattern: "booking/",
     new { Controller = "Home", Action = "Booking" }
   );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
