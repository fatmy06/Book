using Book.Data.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext() { }


       // public virtual DbSet<Books> Books { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                    .HasMany(e => e.Roles)
                    .WithOne()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Book.Data.Models.Book> Book { get; set; } = default!;
    }
}
