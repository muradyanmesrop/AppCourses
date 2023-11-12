using Microsoft.EntityFrameworkCore;
using AppCourses.Core.Db.Entities;

namespace AppCourses.Core.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(k => new { k.CourseId, k.UserId }).HasName("PK_Groups");
            });
        }
    }
}
