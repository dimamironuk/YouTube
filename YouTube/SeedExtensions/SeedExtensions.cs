using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace YouTube.SeedExtensions
{
    public static class Roles
    {
        public const string ADMIN = "admin";
        public const string USER = "user";
    }

    public static class Seeder
    {
        public static async Task SeedRoles(this IServiceProvider app)
        {
            var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = typeof(Roles).GetFields(
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Select(x => (string)x.GetValue(null)!);

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        public static async Task SeedAdmin(this IServiceProvider app)
        {
            var userManager = app.GetRequiredService<UserManager<User>>();

            const string USERNAME = "admin@ukr.net";
            const string PASSWORD = "Qwer-1234";
            const string NICKNAME = "ADMIN";
            const string NAME = "ADMIN";
            const string AVATAR_URL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRkiIFjCOZ-mMeqxd2ryrneiHedE8G9S0AboA&s";
            DateTime BIRTHDAY = new DateTime(2000, 1, 1);

            var existingUser = await userManager.FindByNameAsync(USERNAME);

            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                    Nickname = NICKNAME,
                    Name = NAME,
                    AvatarUrl = AVATAR_URL,
                    Birthday = BIRTHDAY
                };

                var result = await userManager.CreateAsync(user, PASSWORD);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, Roles.ADMIN);
            }
        }
    }
}
