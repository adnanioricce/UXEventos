using Microsoft.EntityFrameworkCore;
using SucessoEventos.Entities;
using SucessoEventos.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>{
    opt.UseSqlServer(connStr);
    if(builder.Environment.IsDevelopment()){
        opt.EnableDetailedErrors();
        opt.EnableSensitiveDataLogging();       
    } 
});
var app = builder.Build();
if(app.Environment.IsDevelopment()){
    
    app.SeedDatabase();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
