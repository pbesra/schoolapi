using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using schoolapi.Application.Services.Student;
using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Constants;
using schoolapi.Controllers.Models.Request;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Entity;
using schoolapi.Infrasctructure.ApiSettings;

namespace schoolapi.Controllers
{
    [ApiController]
    [Route(ApiConstants.API_VERSION)]
    public class StudentController : ControllerBase
    {
        public IAppConfiguration _appConfiguration { get; }
        public IStudentService _studentService { get; }
        public IMapper _mapper { get; }
        public IStudentMetaData _studentMetaData { get; }

        public StudentController(IStudentService studentService, IMapper mapper, IStudentMetaData studentMetaData)
        {
            _studentService = studentService;
            _mapper = mapper;
            _studentMetaData = studentMetaData;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStudentRequest createStudentRequest)
        {
            CreatedStudentResponse response = await _studentService.InsertAsync(createStudentRequest);
            response._MetaData = _studentMetaData.GetResources();
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