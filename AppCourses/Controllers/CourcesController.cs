using Microsoft.AspNetCore.Mvc;
using AppCourses.Core.Models.Add;
using AppCourses.Core.Models.View;
using AppCourses.Core.Abstractions;

namespace AppCourses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourcesController : ControllerBase
    {
        private readonly ICourseBL _courseBL;
        public CourcesController(ICourseBL courseBL)
        {
            _courseBL = courseBL;
        }
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _courseBL.GetCourses();
            return Ok(courses);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult AddCourse([FromBody] CourseAddModel courseModel)
        {
            CourseViewModel courseViewModel = _courseBL.AddCourse(courseModel);
            return Created("", courseViewModel);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult EditCourse([FromRoute] int? id, [FromBody] CourseAddModel courseModel)
        {
            CourseViewModel courseViewModel = _courseBL.EditCourse(id, courseModel);
            return Ok(courseModel);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult RemoveCourse([FromRoute] int? id)
        {
            _courseBL.RemoveCourse(id);
            return Ok();
        }
    }
}
