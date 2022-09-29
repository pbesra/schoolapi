using schoolapi.Controllers.Models.Request;
using schoolapi.Controllers.Models.Response.Student;

namespace schoolapi.Application.Services.Student
{
    public interface IStudentService
    {
        Task<CreatedStudentResponse> InsertAsync(CreateStudentRequest createStudentRequest);
    }
}