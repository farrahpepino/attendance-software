using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data{
    public class AppDbContext: DbContext{
        public DbSet<User> Users {get; set;}
        public DbSet<Schedule> Schedules {get; set;}
        public DbSet<Log> Logs {get; set;}
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder){   
            modelBuilder.Entity<User>()
                .Property(user => user.Status)
                .HasDefaultValue("absent");
        }
    }
}