using Data.Data;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using YouTube.MapperProfiles;
using YouTube.Services;
using YouTube.Validations;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using Data.Entities;
using Core.Interfaces;
using YouTube.SeedExtensions;
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
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<YouTubeDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            builder.Services.AddIdentity<User, IdentityRole>(options =>
                options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultTokenProviders()
                .AddDefaultUI() 
                .AddEntityFrameworkStores<YouTubeDbContext>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddAutoMapper(typeof(AppProfile));
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVideoService, VideoService>();
            builder.Services.AddScoped<ILikeService, LikeService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ISubscriberService, SubscriberService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.SeedRoles().Wait();
                scope.ServiceProvider.SeedAdmin().Wait();
            }
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

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Video}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
