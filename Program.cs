using Microsoft.EntityFrameworkCore;
using PetShopMosh.Data;
using PetShopMosh.Repository;

var builder = WebApplication.CreateBuilder(args);
// string connectionString = "Server=(localdb)\\AspNetCoreCourse;Database=HumanResources;Trusted_Connection=True;";

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PShopContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddTransient<IRepository,Repository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}");


app.Run();
