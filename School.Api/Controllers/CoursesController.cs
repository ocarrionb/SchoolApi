using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Service.Courses;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _coursesService; 
        public CoursesController(ICourseService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            try
            {
                var coursesResponse = _coursesService.GetAllCourses();
                return coursesResponse == null ? NotFound() : Ok(coursesResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
