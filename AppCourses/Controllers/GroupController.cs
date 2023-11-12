using Microsoft.AspNetCore.Mvc;
using AppCourses.Core.Models.View;
using Microsoft.AspNetCore.Authorization;
using AppCourses.Core.Abstractions;
using System.Security.Claims;

namespace AppCourses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupBL _groupBL;
        //private int? _userId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public GroupController(IGroupBL groupBL)
        {
            _groupBL = groupBL;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetGroups()
        {
            var gorups = _groupBL.GetGroups();
            return Ok(gorups);
        }
        [HttpGet("{userId}")]
        //[Authorize(Roles = "User")]
        public IActionResult GetGroupByUser([FromRoute] int? userId)
        {
            var gorups = _groupBL.GetGroups(userId);
            return Ok(gorups);
        }

        [HttpPost("{userId}, {courseId}")]
        //[Authorize(Roles = "User")]
        public IActionResult AddGroup([FromRoute] int? userId, [FromRoute] int? courseId)
        {
            GroupViewModel groupViewModel = _groupBL.AddGroup(userId, courseId);
            return Created("", groupViewModel);
        }

        [HttpDelete("{userId}, {courseId}")]
        //[Authorize(Roles = "User")]
        public IActionResult RemoveUser([FromRoute] int? userId, [FromRoute] int? courseId)
        {
            _groupBL.RemoveGroup(userId, courseId);
            return Ok();
        }
    }
}
