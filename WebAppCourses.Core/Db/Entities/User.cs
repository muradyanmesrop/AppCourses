using AppCourses.Core.Enums;

namespace AppCourses.Core.Db.Entities
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
        }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public Role? Role { get; set; }
        public string? Password { get; set; }
        public ICollection<Group>? Groups { get; set; }
    }
}
