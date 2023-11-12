using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Core.Models.View
{
    public class GroupViewModel
    {
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
    }
}
