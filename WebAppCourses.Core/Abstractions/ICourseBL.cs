using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;

namespace AppCourses.Core.Abstractions
{
    public interface ICourseBL
    {
        IEnumerable<CourseViewModel> GetCourses();
        CourseViewModel AddCourse(CourseAddModel courseModel);
        CourseViewModel EditCourse(int? id, CourseAddModel courseModel);
        void RemoveCourse(int? id);
    }
}
