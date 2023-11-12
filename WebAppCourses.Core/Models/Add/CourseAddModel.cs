using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models.Abstract;

namespace AppCourses.Core.Models.Add
{
    public class CourseAddModel : CourseModel
    {
        public static implicit operator Course(CourseAddModel courseModel)
        {
            return new Course
            {
                CourseName = courseModel.CourseName
            };
        }
    }
}
