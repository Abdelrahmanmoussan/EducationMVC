using IdentityText.Enums;
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

            // First admin user (Amin)
            var adminUser1 = new ApplicationUser
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
            adminUser1.PasswordHash = hasher.HashPassword(adminUser1, "Admin@1234");

            // Second admin user (Abdelrahman Moussan)
            var adminUser2 = new ApplicationUser
            {
                Id = "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91", // Generate a new GUID
                UserName = "abdelrahman",
                NormalizedUserName = "ABDELRAHMAN",
                Email = "abdelrahmanmoussan@gmail.com",
                NormalizedEmail = "ABDELRAHMANMOUSSAN@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Abdelrahman",
                LastName = "Moussan",
                Address = "Port Said",
                Photo = "Moussan.jpg"
            };
            adminUser2.PasswordHash = hasher.HashPassword(adminUser2, "Admin@1234");

            // Seed users
            builder.Entity<ApplicationUser>().HasData(adminUser1, adminUser2);


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
               },
                new IdentityUserRole<string>
                {
                    UserId = "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91", // Abdelrahman
                    RoleId = "5aa54943-8b55-4399-91b7-d247ab235cf3"
                }
           );

            // seeding data for subject table
            builder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 1,
                    Title = "الرياضيات",
                    Description = "مادة الرياضيات الأساسية",
                    SubjectType = SubjectType.General
                },
                new Subject
                {
                    SubjectId = 2,
                    Title = "العلوم",
                    Description = "مادة العلوم الأساسية",
                    SubjectType = SubjectType.General
                },
                new Subject
                {
                    SubjectId = 3,
                    Title = "اللغة العربية",
                    Description = "مادة اللغة العربية الأساسية",
                    SubjectType = SubjectType.General
                },
                new Subject
                {
                    SubjectId = 4,
                    Title = "اللغة الإنجليزية",
                    Description = "مادة اللغة الإنجليزية الأساسية",
                    SubjectType = SubjectType.Optional
                },
                new Subject
                {
                    SubjectId = 5,
                    Title = "الدراسات الاجتماعية",
                    Description = "مادة الدراسات الاجتماعية الأساسية",
                    SubjectType = SubjectType.Optional
                }
            );
            builder.Entity<AcademicYear>().HasData(
                new AcademicYear
                {
                    AcademicYearId = 1,
                    Name = "one"
                },
                new AcademicYear
                {
                    AcademicYearId = 2,
                    Name = "two"
                },
                new AcademicYear
                {
                    AcademicYearId = 3,
                    Name = "three"
                }
            );
            builder.Entity<Subscription>().HasData(
                new Subscription
                {
                    SubscriptionId = 1,
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 12, 31),
                    Code = "SUBS2024A",
                    SubscriptionStatus = SubscriptionStatus.Active
                },
                new Subscription
                {
                    SubscriptionId = 2,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 12, 31),
                    Code = "SUBS2023B",
                    SubscriptionStatus = SubscriptionStatus.Expired
                }
);



        }

    }
}
