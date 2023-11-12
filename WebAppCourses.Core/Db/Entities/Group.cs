using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Core.Db.Entities
{
    public class Group
    {
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}
