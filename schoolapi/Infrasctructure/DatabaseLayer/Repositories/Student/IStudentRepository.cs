using schoolapi.Entity;

namespace schoolapi.Infrasctructure.DatabaseLayer.Repositories.Student
{
    public interface IStudentRepository
    {
        Task<StudentEntity> InsertAsync(StudentEntity studentEntity);

        Task<StudentEntity> GetAsync(StudentEntity studentEntity);
    }
}