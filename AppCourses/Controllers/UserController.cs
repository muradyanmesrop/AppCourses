using Microsoft.AspNetCore.Mvc;
using System;
using AppCourses.Core.Db;
using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;
using AppCourses.Core.Abstractions;

namespace AppCourses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        //private int? _userId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var users = _userBL.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserAddModel UserModel)
        {
            if(UserModel == null) return BadRequest("User model is null.");
            UserViewModel viewModel = _userBL.AddUser(UserModel);
            return Created("", viewModel);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "User")]
        public IActionResult EditUser([FromRoute] int? id, [FromBody] UserAddModel userModel)
        {
            UserViewModel userViewModel = _userBL.EditUser(id, userModel);
            return Ok(userViewModel);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "User")]
        public IActionResult RemoveUser([FromRoute] int? id)
        {
            _userBL.RenoveUser(id);
            return Ok();
        }
    }
}
