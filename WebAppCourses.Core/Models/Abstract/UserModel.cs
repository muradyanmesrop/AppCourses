using AppCourses.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppCourses.Core.Models.Abstract
{
    public abstract class UserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Role? Role { get; set; }
    }
}
