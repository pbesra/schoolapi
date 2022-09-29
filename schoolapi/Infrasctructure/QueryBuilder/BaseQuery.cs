namespace schoolapi.Infrasctructure.QueryBuilder
{
    public class BaseQuery<T> where T : class
    {
        public QueryBuilderResponse Build()
        {
            return new QueryBuilderResponse();
        }
    }
}