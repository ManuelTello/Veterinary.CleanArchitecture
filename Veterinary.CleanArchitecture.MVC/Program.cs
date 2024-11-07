using Microsoft.EntityFrameworkCore;
using Veterinary.CleanArchitecture.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var veterinaryConnection = builder.Configuration.GetConnectionString("VeterinaryConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(options =>
{
   options.RegisterServicesFromAssembly(typeof(Program).Assembly); 
});
builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
    options.UseMySql(veterinaryConnection,new MySqlServerVersion(new Version(8, 0, 30)));
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