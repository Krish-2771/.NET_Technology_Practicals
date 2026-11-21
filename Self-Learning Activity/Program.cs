var builder = WebApplication.CreateBuilder(args);

// Register MVC (controllers + Razor views) with the DI container
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();   // serves files from wwwroot
app.UseRouting();
app.UseAuthorization();

// Default route: {controller=Home}/{action=Index}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
