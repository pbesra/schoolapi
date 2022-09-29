using Microsoft.AspNetCore.Mvc;
using schoolapi.Controllers.Models.Request;
using schoolapi.Infrasctructure.ApiSettings;

namespace schoolapi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        public IAppConfiguration _appConfiguration { get; }

        public UserController(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        [HttpPost(Name = "student")]
        public IActionResult CreateAsync([FromBody] CreateStudentRequest createStudentRequest)
        {
            var res = createStudentRequest;
            _appConfiguration.Read();
            return Ok(createStudentRequest);
        }
    }
}