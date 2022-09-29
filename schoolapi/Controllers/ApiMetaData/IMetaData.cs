namespace schoolapi.Controllers.ApiMetaData
{
    public interface IMetaData<T, V>
    {
        IEnumerable<ResourceLink> GetResources();
        void AddResource(ResourceLink resource);
        void AddResources(IEnumerable<ResourceLink> resources);
        V OnResourceCreated(T entity);
    }
}
