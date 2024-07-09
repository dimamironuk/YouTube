using Microsoft.EntityFrameworkCore;
using YouTube.Entities;

namespace YouTube.Data
{
    public class YouTubeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YouTubeMvc;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User { Id = 1, Nicname = "JohnDoe", Name = "John Doe", Email = "john.doe@example.com", Birthday = new DateTime(1990, 5, 15), AvatarUrl = null},
                new User { Id = 2, Nicname = "JaneSmith", Name = "Jane Smith", Email = "jane.smith@example.com", Birthday = new DateTime(1985, 10, 25), AvatarUrl = null },
                new User { Id = 3, Nicname = "MichaelBrown", Name = "Michael Brown", Email = "michael.brown@example.com", Birthday = new DateTime(1988, 3, 8), AvatarUrl = null },
                new User { Id = 4, Nicname = "EmilyJohnson", Name = "Emily Johnson", Email = "emily.johnson@example.com", Birthday = new DateTime(1995, 7, 12), AvatarUrl = null },
                new User { Id = 5, Nicname = "WilliamWilson", Name = "William Wilson", Email = "william.wilson@example.com", Birthday = new DateTime(1992, 9, 20), AvatarUrl = null },
                new User { Id = 6, Nicname = "OliviaDavis", Name = "Olivia Davis", Email = "olivia.davis@example.com", Birthday = new DateTime(1987, 12, 3), AvatarUrl = null },
                new User { Id = 7, Nicname = "JamesMiller", Name = "James Miller", Email = "james.miller@example.com", Birthday = new DateTime(1993, 4, 18), AvatarUrl = null },
                new User { Id = 8, Nicname = "SophiaMartinez", Name = "Sophia Martinez", Email = "sophia.martinez@example.com", Birthday = new DateTime(1983, 6, 30), AvatarUrl = null },
                new User { Id = 9, Nicname = "BenjaminGarcia", Name = "Benjamin Garcia", Email = "benjamin.garcia@example.com", Birthday = new DateTime(1991, 8, 7), AvatarUrl = null },
                new User { Id = 10, Nicname = "IsabellaLopez", Name = "Isabella Lopez", Email = "isabella.lopez@example.com", Birthday = new DateTime(1989, 11, 22), AvatarUrl = null }
            });
        }
        public DbSet<User> Users { get; set; }
    }
}
