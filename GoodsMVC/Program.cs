using GoodsMVC.Config;
using GoodsMVC.Services;

namespace GoodsMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));

            //var apiConfig = builder.Configuration.GetSection("ApiConfig").Get<ApiConfig>();

            builder.Services.AddScoped<HttpClientService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Goods}/{action=Index}/{id?}");

            app.Run();
        }
    }
}