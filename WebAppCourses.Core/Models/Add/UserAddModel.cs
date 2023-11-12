using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models.Abstract;

namespace AppCourses.Core.Models.Add
{
    public class UserAddModel : UserModel
    {
        public string Password { get; set; }
        public string AdressHomeNbr { get; set; }
        public string AdressStreetNumber { get; set; }
        public string AdressCity { get; set; }
        public string AdressCountry { get; set; }

        public static implicit operator User(UserAddModel userModel)
        {
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateofBirth = userModel.DateofBirth,
                Email = userModel.Email,
                PhoneNumber = userModel.PhoneNumber,
                Role = userModel.Role,
                Password=userModel.Password
            };
            user.Address = GetAdressFull(userModel);
            return user;
        }
        private static string GetAdressFull(UserAddModel userModel)
        {
            return $"{userModel.AdressHomeNbr?.Replace(".", " ")} {userModel.AdressStreetNumber?.Replace(".", " ")} {userModel.AdressCity?.Replace(".", " ")} {userModel.AdressCountry?.Replace(".", " ")}";
        }
    }
}
