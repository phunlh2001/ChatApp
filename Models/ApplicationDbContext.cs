using Microsoft.EntityFrameworkCore;

namespace ChatApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration table by entity
            modelBuilder.Entity<Account>().ToTable("Accounts");

            // seed data
            modelBuilder.Entity<Account>().HasData(
                    new Account
                    {
                        ID = 1,
                        Username = "hungphu",
                        Password = "123456"
                    },
                    new Account
                    {
                        ID = 2,
                        Username = "kaiz0402",
                        Password = "123456"
                    }
                );
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
