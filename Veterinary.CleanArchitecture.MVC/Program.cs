using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Veterinary.CleanArchitecture.Domain.IRepositories;
using Veterinary.CleanArchitecture.Infrastructure.Data;
using Veterinary.CleanArchitecture.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
var veterinaryConnectionString = builder.Configuration.GetConnectionString("VeterinaryConnection");
var mediatrHandlersAssembly = Assembly.Load("Veterinary.CleanArchitecture.Application");

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddMediatR(options =>
{
   options.RegisterServicesFromAssembly(mediatrHandlersAssembly); 
});
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    options.UseMySql(veterinaryConnectionString,new MySqlServerVersion(new Version(8, 0, 30)));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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