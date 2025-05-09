using IdentityText.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityText.Models;
using Microsoft.Extensions.DependencyInjection;
using IdentityText.Repository.IRepository;
using IdentityText.Repository;

namespace IdentityText
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
            builder.Services.AddScoped<ILectureRepository, LectureRepository>();
            builder.Services.AddScoped<IAcademicYearRepository, AcademicYearRepository>();
            builder.Services.AddScoped<IPrivateLessonRepository, PrivateLessonRepository>();
            builder.Services.AddScoped<IClassGroupRepository, ClassGroupRepository>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{Area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
