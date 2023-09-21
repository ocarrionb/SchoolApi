using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Requests.Members;
using School.Domain.Responses.Course;
using School.Service.Members;
using System.Net;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _membersService;
        public MembersController(IMemberService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromQuery]GetMemberByIdRequest request)
        {
            try
            {
                var memberResponse = _membersService.GetMember(request);
                return memberResponse.MemberId > 0 ? Ok(memberResponse) : NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] CreateMemberRequest request)
        {
            try
            {
                var memberResponse = _membersService.PostMember(request);
                return memberResponse != null ? Created("Created", memberResponse) : StatusCode(503, "Internal server error, not stored correctly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, "Internal server error, please contact support");
            }
        }
    }
}
