using schoolapi.Entity;

namespace schoolapi.Controllers.ApiMetaData
{
    public class ResourceLink
    {
        public string Href { get; set; }
        public string Type { get; set; }
        public string Rel { get; set; }
    }

    public class StudentMetaData: IStudentMetaData
    {
        List<ResourceLink> ResourceLink = new List<ResourceLink>
        {
            new ResourceLink{Href="Student", Rel="Create", Type="POST"},
            new ResourceLink{Href="Student", Rel="GetListOfStudents", Type="GET"}
        };
        public  List<ResourceLink> GetResources()
        {
            return ResourceLink;
        }
        public void AddResource(ResourceLink resource)
        {
            ResourceLink.Add(resource);
        }
        public void AddResources(List<ResourceLink> resources)
        {
            ResourceLink = ResourceLink.Concat(resources).ToList();
        }

        public void OnResourceCreated(int id)
        {
            
        }
    }
}