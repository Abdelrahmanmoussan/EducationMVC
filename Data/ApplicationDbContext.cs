using IdentityText.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;

namespace IdentityText.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentResult> AssessmentResults { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassGroup> ClassGroups { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrivateLesson> PrivateLessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<TeacherAcademicYear> TeacherAcademicYears { get; set; }
        public DbSet<PrivateLessonStudent> PrivateLessonStudents { get; set; }
        public DbSet<SubjectAcademicYear> SubjectAcademicYears { get; set; }
        public DbSet<NotificationRecipient> NotificationRecipients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ===== TeacherAcademicYear =====
            builder.Entity<TeacherAcademicYear>()
                .HasKey(x => new { x.TeacherId, x.AcademicYearId });
            // ===== PrivateLessonStudent =====
            builder.Entity<PrivateLessonStudent>()
                .HasKey(x => new { x.PrivateLessonId, x.StudentId });
            // ===== SubjectAcademicYear =====
            builder.Entity<SubjectAcademicYear>()
                .HasKey(x => new { x.SubjectId, x.AcademicYearId });
            // ===== NotificationRecipient =====
            builder.Entity<NotificationRecipient>()
                .HasKey(x => new { x.NotificationId, x.NotificationRecipientId });

            
            builder.Entity<Attendance>()
                .HasOne(a => a.Enrollment)
                .WithMany()
                .HasForeignKey(a => a.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Attendance>()
               .HasOne(a => a.Student)
               .WithMany()
               .HasForeignKey(a => a.StudentId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Payment>()
                .HasOne(p => p.Teacher)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ClassGroup>()
                .HasOne(cg => cg.Teacher)
                .WithMany(t => t.ClassGroups)
                .HasForeignKey(cg => cg.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PrivateLesson>()
                .HasOne(pl => pl.Teacher)
                .WithMany(t => t.PrivateLessons)
                .HasForeignKey(pl => pl.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
           


            var hasher = new PasswordHasher<ApplicationUser>();
            
            // Seeding roles and users
            var adminUser = new ApplicationUser
            {
                Id = "7aafd540-fdf8-482b-804d-780fb6726703",
                UserName = "amin",
                NormalizedUserName = "AMIN",
                Email = "amin@gmail.com",
                NormalizedEmail = "AMIN@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Amin",
                LastName = "Mohamed",
                Address = "Quesna,Menofia",
                Photo = "admin.jpg"
            };

            // Generate hashed password
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@1234");

            builder.Entity<ApplicationUser>().HasData(adminUser);


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "5aa54943-8b55-4399-91b7-d247ab235cf3",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "8bbc91c3-0b30-4451-b78e-a26edf6e1c61",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "8ccc91c3-0b30-4451-b78e-a26edf6e1c61",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole
                {
                    Id = "8ddc91c3-0b30-4451-b78e-a26edf6e1c61",
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                }
            );
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   UserId = "7aafd540-fdf8-482b-804d-780fb6726703",
                   RoleId = "5aa54943-8b55-4399-91b7-d247ab235cf3"
               }
           );

        }

    }
}
