using AppCourses.Core.Abstractions;
using AppCourses.Core.Db;
using AppCourses.Core.Db.Entities;
using AppCourses.Core.Exceptions;
using AppCourses.Core.Models.Abstract;
using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;

namespace AppCourses.BL.Operations
{
    public class UserBL : IUserBL
    {
        private readonly AppDbContext _db;

        public UserBL(AppDbContext db)
        {
            _db = db;           
        }

        public UserViewModel AddUser(UserAddModel UserModel)
        {
            UserModel.Password = BCrypt.Net.BCrypt.HashPassword(UserModel.Password);

            if (VerifyUserBeforeAdd(UserModel))
            {
                throw new LogicException("Duplicate e-mail");
            }
            User user = UserModel;
            _db.Users.Add(user);
            _db.SaveChanges();
            UserViewModel userViewModel = user;
            return userViewModel;
        }

        private bool VerifyUserBeforeAdd(UserAddModel UserModel)
        {
            return _db.Users.Where(x => x.Email == UserModel.Email).FirstOrDefault() != null ||
                   UserModel.Role == null || UserModel.FirstName == null || UserModel.Password == null ||
                   UserModel.Email == null;
        }

        public UserViewModel EditUser(int? id, UserAddModel userModel)
        {
            if (id == null || userModel == null)
            {
                throw new LogicException("Duplicate e-mail");
            }
            User user = userModel;
            user.UserId = id;
            _db.Update(user);
            _db.SaveChanges();
            UserViewModel userViewModel = user;
            return userViewModel;
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _db.Users.Select(u => new UserViewModel(u)).ToList();
        }

        public void RenoveUser(int? id)
        {
            User user = _db.Users.Find(id);
            _db.Remove(user);
            _db.SaveChanges();
        }
    }
}
