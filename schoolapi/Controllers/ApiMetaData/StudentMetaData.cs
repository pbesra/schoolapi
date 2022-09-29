using schoolapi.Controllers.Models.Response.Student;
using schoolapi.Entity;

namespace schoolapi.Controllers.ApiMetaData
{
    public class ResourceLink
    {
        public string Href { get; set; }
        public string Type { get; set; }
        public string Rel { get; set; }
    }

    public class StudentMetaData: IMetaData<CreatedStudentResponse, StudentMetaData>
    {
        
        
        IEnumerable<ResourceLink> _resourceLink;
        public StudentMetaData()
        {
            _resourceLink = new List<ResourceLink>() {
                new ResourceLink{Href="Student", Rel="Create", Type="POST"},
                new ResourceLink{Href="Student", Rel="GetListOfStudents", Type="GET"}
            };
        }

        public IEnumerable<ResourceLink> GetResources()
        {
            return _resourceLink;
        }
        public void AddResource(ResourceLink resource)
        {
            _resourceLink.ToList().Add(resource);
        }
        public void AddResources(IEnumerable<ResourceLink> resources)
        {
            _resourceLink = _resourceLink.Concat(resources).ToList();
        }

        public  StudentMetaData OnResourceCreated(CreatedStudentResponse createdStudentResponse)
        {
            _resourceLink=_resourceLink.Concat(new List<ResourceLink> {
                new ResourceLink { Href = $"Student/{createdStudentResponse?.Id}", Rel = "UpdateStudent", Type = "PUT" },
                new ResourceLink { Href = $"Student/{createdStudentResponse?.Id}", Rel = "GetStudent", Type = "GET" },
                new ResourceLink { Href = $"Student/{createdStudentResponse?.Id}", Rel = "DeleteStudent", Type = "DELETE" }
            });
            return this;
        }

    }
}