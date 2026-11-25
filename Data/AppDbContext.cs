using Microsoft.EntityFrameworkCore;
using StudentPortalEntityFramework.Models;

namespace StudentPortalEntityFramework.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Each DbSet becomes a table in the database
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data: inserted when the database is first created
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "Anita Gurung", Email = "anita@example.com", Semester = 1 },
            new Student { Id = 2, Name = "Bikash Thapa", Email = "bikash@example.com", Semester = 2 },
            new Student { Id = 3, Name = "Sita Sharma",  Email = "sita@example.com",  Semester = 3 });
    }
}
