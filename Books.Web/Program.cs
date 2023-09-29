using Books.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddMyDbContext(builder.Configuration)
    .AddMappers()
    .AddRepositories()
    .AddManagers()
    .AddHelpers(builder.Configuration)
    .AddViewManagers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseLocalization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Home}/{id?}");

app.Run();
