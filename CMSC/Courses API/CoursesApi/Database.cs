using CoursesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi
{
    public class Database : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseReview> Reviews { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\Matt\source\repos\CoursesApi\CoursesApi\wwwroot\database.db");
#else
            optionsBuilder.UseSqlite(@"Data Source=d:\home\site\wwwroot\wwwroot\database.db");
#endif
        }
    }
}
