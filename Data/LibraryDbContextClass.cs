using Library.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext 
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Borrows> Borrows { get; set; }

        public DbSet<Doc> Docs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Borrows>()
                .HasOne(b => b.User) // borrower
                .WithMany()
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Borrows>()
                .HasOne(b => b.CreateBy) // librarian
                .WithMany()
                .HasForeignKey(b => b.CreateById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .Property(u => u.Type)
                .HasConversion<string>();
        }

    }
}
