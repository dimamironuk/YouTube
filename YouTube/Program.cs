using Data.Data;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using YouTube.MapperProfiles;
using YouTube.Services;
using YouTube.Validations;
namespace YouTube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration.GetConnectionString("LocalDb");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<YouTubeDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

            builder.Services.AddAutoMapper(typeof(AppProfile));
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<VideoService>();

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

            app.UseSession();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Video}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
