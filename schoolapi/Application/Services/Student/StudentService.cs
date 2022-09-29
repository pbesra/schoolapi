using AutoMapper;
using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Models.Request;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Entity;
using schoolapi.Infrasctructure.DatabaseLayer.Repositories.Student;

namespace schoolapi.Application.Services.Student
{
    public class StudentService : IStudentService
    {
        public IStudentRepository _studentRepository { get; }
        private readonly IMapper _mapper;
        private readonly IStudentMetaData _studentMetaData;

        public StudentService(IStudentRepository studentRepository, IMapper mapper, IStudentMetaData studentMetaData)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _studentMetaData = studentMetaData;
        }

        public async Task<CreatedStudentResponse> InsertAsync(CreateStudentRequest createStudentRequest)
        {
            var entity = _mapper.Map<CreateStudentRequest, StudentEntity>(createStudentRequest);

            var response = await _studentRepository.InsertAsync(entity);
            var filteredRes = _mapper.Map<StudentEntity, CreatedStudentResponse>(response);
            _studentMetaData.AddResources(new List<ResourceLink> {
                new ResourceLink { Href = $"Student/{filteredRes?.Id}", Rel = "UpdateStudent", Type = "PUT" },
                new ResourceLink { Href = $"Student/{filteredRes?.Id}", Rel = "GetStudent", Type = "GET" },
                new ResourceLink { Href = $"Student/{filteredRes?.Id}", Rel = "DeleteStudent", Type = "DELETE" }
            });
            return filteredRes;
        }
    }
}