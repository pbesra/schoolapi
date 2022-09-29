using schoolapi.Application.Services.Student;
using schoolapi.Controllers.ApiMetaData;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Infrasctructure.DatabaseLayer.DbConfig;
using schoolapi.Infrasctructure.DatabaseLayer.Repositories.Student;
using schoolapi.Service.Implemetations;
using schoolapi.Service.Interfaces;

namespace schoolapi.Extensions.ServiceDI
{
    public static class ServiceDI
    {
        public static void ServiceInjection(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IDBConfig, DbConfig>();
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<IMetaData<CreatedStudentResponse, StudentMetaData>, StudentMetaData>();
        }
    }
}
