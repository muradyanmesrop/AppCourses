using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Core.Db.Entities
{
    public class Course
    {
        public Course()
        {
            Groups = new HashSet<Group>();
        }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public ICollection<Group>? Groups { get; set; }
    }
}
