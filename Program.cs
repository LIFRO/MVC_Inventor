using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using MVC_Training.Models;
using MVC_Training.Repositories;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

        // Add services to the container
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IAlsterRepository, EfAlsterRepository>();
        builder.Services.AddDbContext<AlsterDbContext>(options => options.UseInMemoryDatabase("AlsterDb"));

        var app = builder.Build();

        // Seed in-memory database from JSON once
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AlsterDbContext>();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            if (!db.Alsters.Any())
            {
                var file = Path.Combine(env.ContentRootPath, "Data", "Alster.json");
                var json = File.ReadAllText(file);
                var alsters = JsonSerializer.Deserialize<List<Alster>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
                db.Alsters.AddRange(alsters);
                db.SaveChanges();
            }
        }

        // Configure the HTTP request pipeline
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        app.Run();
    }
}
