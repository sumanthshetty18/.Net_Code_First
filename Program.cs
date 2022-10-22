using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TE_CodeFirst.Data;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);
 

// NToastNotify
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000 //5 seconds
});

builder.Services.AddDbContext<TE_CodeFirstContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TE_CodeFirstContext") ?? throw new InvalidOperationException("Connection string 'TE_CodeFirstContext' not found.")));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
