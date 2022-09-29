using Dapper;

namespace schoolapi.Infrasctructure.QueryBuilder
{
    public class QueryBuilderResponse
    {
        public string Query { get; set; }
        public DynamicParameters Parameter { get; set; }
    }
}