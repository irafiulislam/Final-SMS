using Final_SMS.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_SMS.Data
{
    public class AppData : DbContext
    {
        public AppData(DbContextOptions<AppData>options):base(options){ } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MDRAFIULISLAM\\SQLEXPRESS;Database=sms;Integrated Security=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                        .HasMany(a => a.AttendedCourse)
                        .WithMany(c => c.Students);
            modelBuilder.Entity<Student>()
                        .HasMany(se => se.SemestersAttended)
                        .WithMany(s => s.Students);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }

    }
}
