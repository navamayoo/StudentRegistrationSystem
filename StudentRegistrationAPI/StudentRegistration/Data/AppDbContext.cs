using Microsoft.EntityFrameworkCore;
using StudentRegistration.Models;

namespace StudentRegistration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherClass>()
                .HasOne(t => t.Teacher)
                .WithMany(tc => tc.TeacherClasses)
                .HasForeignKey(t1 => t1.TeacherId);

            modelBuilder.Entity<TeacherClass>()
                 .HasOne(c => c.Class)
                 .WithMany(tc => tc.TeacherClasses)
                 .HasForeignKey(c1 => c1.ClassId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(t => t.Teacher)
                .WithMany(tc => tc.TeacherSubjects)
                .HasForeignKey(t1 => t1.TeacherId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(s => s.Subject)
                .WithMany(tc => tc.TeacherSubjects)
                .HasForeignKey(s1 => s1.SubjectId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

    }
}

