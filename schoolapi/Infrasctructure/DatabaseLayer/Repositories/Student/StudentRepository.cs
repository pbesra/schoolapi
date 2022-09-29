using Dapper;
using schoolapi.Entity;
using schoolapi.Infrasctructure.DatabaseLayer.DbConfig;

namespace schoolapi.Infrasctructure.DatabaseLayer.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDBConfig _dbConfig;

        public StudentRepository(IDBConfig dBConfig, IDBConfig dbConfig)
        {
            _dbConfig = dbConfig;
        }

        private object GetQueryKeyValueParameters(StudentEntity studentEntity)
        {
            return new
            {
                gender = studentEntity.Gender,
                firstName = studentEntity.FirstName,
                lastName = studentEntity.LastName,
                dateOfBirth = Convert.ToDateTime(studentEntity.DateOfBirth),
                contact = studentEntity.Contact,
                email = studentEntity.Email,
                middleName = studentEntity.MiddleName,
                createdOn = DateTime.Now,
                isActive = 1,
                parents = studentEntity.Parents,
                guardian = studentEntity.Guardian,
                addresses = studentEntity.Addresses,
            };
        }

        public async Task<StudentEntity> InsertAsync(StudentEntity studentEntity)
        {
            var commandParams = GetQueryKeyValueParameters(studentEntity);
            var studentInsertCommand = @"insert into student(
                                                gender,
                                                firstName,
                                                lastName,
                                                dateOfBirth,
                                                contact,
                                                email,
                                                middleName,
                                                createdOn,
                                                isActive,
                                                parents,
                                                guardian,
                                                addresses) OUTPUT INSERTED.*
                                            values
                                                (@gender,
                                                @firstName,
                                                @lastName,
                                                @dateOfBirth,
                                                @contact,
                                                @email,
                                                @middleName,
                                                @createdOn,
                                                @isActive,
                                                @parents,
                                                @guardian,
                                                @addresses)";
            using (var connection = _dbConfig.GetConnection())
            {
                connection.Open();
                int studentRows = 0;/* await connection
                    .ExecuteAsync(studentInsertCommand, commandParams)
                    .ConfigureAwait(false);*/
                var obj = connection.QuerySingle<StudentEntity>(
                                studentInsertCommand,
                                commandParams);
                return obj;
            }
        }

        public Task<StudentEntity> GetAsync(StudentEntity studentEntity)
        {
            throw new NotImplementedException();
        }
    }
}