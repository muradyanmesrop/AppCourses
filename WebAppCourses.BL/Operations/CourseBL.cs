using AppCourses.Core.Abstractions;
using AppCourses.Core.Db;
using AppCourses.Core.Db.Entities;
using AppCourses.Core.Exceptions;
using AppCourses.Core.Models.Abstract;
using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;

namespace AppCourses.BL.Operations
{
    public class CourseBL : ICourseBL
    {
        private readonly AppDbContext _db;

        public CourseBL(AppDbContext db)
        {
            _db = db;
        }
        public CourseViewModel AddCourse(CourseAddModel courseModel)
        {
            if(courseModel == null)
            {
                throw new LogicException("Duplicate e-mail");
            }
            Course course = courseModel;
            _db.Courses.Add(course);
            _db.SaveChanges();
            CourseViewModel courseViewModel = course;
            return courseViewModel;
        }

        public CourseViewModel EditCourse(int? id, CourseAddModel courseModel)
        {
            if (id == null || courseModel == null)
            {
                throw new LogicException("Duplicate e-mail");
            }
            Course course = courseModel;
            course.CourseId = id;
            _db.Update(course);
            _db.SaveChanges();
            CourseViewModel courseViewModel = course;
            return courseViewModel;
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            var courses = _db.Courses.Select(c => new CourseViewModel(c)).ToList();
            return courses;
        }

        public void RemoveCourse(int? id)
        {
            if (id == null)
            {
                throw new LogicException("Duplicate e-mail");
            }
            Course course = _db.Courses.Find(id);
            _db.Remove(course);
            _db.SaveChanges();
        }
    }
}
