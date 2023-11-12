using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Core.Abstractions
{
    public interface IUserBL
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel AddUser(UserAddModel UserModel);
        UserViewModel EditUser(int? id, UserAddModel userModel);
        void RenoveUser(int? id);
    }
}
