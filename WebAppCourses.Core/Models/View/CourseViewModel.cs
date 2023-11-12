using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models.Abstract;

namespace AppCourses.Core.Models.View
{
    public class CourseViewModel : CourseModel
    {
        public int? CourseId { get; set; }

        public CourseViewModel(Course course)
        {
            CourseId = course.CourseId;
            CourseName = course.CourseName;
        }
        public static implicit operator Course(CourseViewModel courseModel)
        {
            return new Course
            {
                CourseName = courseModel.CourseName
            };
        }
        public static implicit operator CourseViewModel(Course course)
        {
            return new CourseViewModel(course);
        }
    }
}
