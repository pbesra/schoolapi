using AutoMapper;
using Newtonsoft.Json;
using schoolapi.Controllers.Models.Request;
using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Entity;

namespace schoolapi.Controllers.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateStudentRequest, StudentEntity>()
                .ForPath(dest => dest.Parents,
                    opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Parents)))
                .ForPath(dest => dest.Guardian,
                    opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Guardian)))
                .ForPath(dest => dest.Addresses,
                    opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.Addresses)));

            CreateMap<StudentEntity, CreatedStudentResponse>()
               .ForPath(dest => dest.Parents,
                   opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.Parents)))
               .ForPath(dest => dest.Guardian,
                   opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.Guardian)))
               .ForPath(dest => dest.Addresses,
                   opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.Addresses)));


            
        }
    }
}