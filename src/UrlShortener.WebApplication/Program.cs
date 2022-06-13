using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using UrlShortener.Data;
using UrlShortener.Domain.Url;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUrlManager, UrlManager>();
builder.Services.AddSingleton<IBaseEncoder, BaseEncoder>();
builder.Services.AddScoped<IUrlShortener, UrlShortener.Domain.Url.UrlShortener>();
builder.Services.AddDbContext<DomainDbContext>();
builder.Services.AddSpaStaticFiles(configuration => { configuration.RootPath = "src/build"; });
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseCors("default");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
