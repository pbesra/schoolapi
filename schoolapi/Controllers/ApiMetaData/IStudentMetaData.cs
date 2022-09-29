namespace schoolapi.Controllers.ApiMetaData
{
    public interface IStudentMetaData
    {
        List<ResourceLink> GetResources();


        void AddResource(ResourceLink resource);
        void AddResources(List<ResourceLink> resources);

        
    }
}
