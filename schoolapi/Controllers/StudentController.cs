using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using schoolapi.Application.Services.Student;
using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Constants;
using schoolapi.Controllers.Models.Request;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Entity;

namespace schoolapi.Controllers
{
    [ApiController]
    [Route(ApiConstants.API_VERSION)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStudentRequest createStudentRequest)
        {
            CreatedStudentResponse response = await _studentService.InsertAsync(createStudentRequest);
            return Created($"", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var response = new List<StudentEntity>{
                new StudentEntity{Id=1, FirstName="jon"},
                new StudentEntity{Id=1, FirstName="Amar"},
                new StudentEntity{Id=1, FirstName="jyoti"},
            };
            return Ok(response);
        }
    }
}