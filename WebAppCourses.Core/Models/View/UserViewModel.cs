using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models.Abstract;

namespace AppCourses.Core.Models.View
{
    public class UserViewModel : UserModel
    {
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string? Address { get; set; }
        public UserViewModel() { }
        public UserViewModel(User user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateofBirth = user.DateofBirth;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            Role = user.Role;
        }

        public int? UserId { get; set; }

        public static implicit operator User(UserViewModel userModel)
        {
            return new User
            {
                UserId = userModel.UserId,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateofBirth = userModel.DateofBirth,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber,
                Address = userModel.Address,
                Role = userModel.Role
            };
        }

        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel(user);
        }
    }
}
