using System;
using Microsoft.AspNetCore.Http;

namespace ProfileManagementApi.Models.ViewModels
{
    public class ProjectsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }

    public class ProjectsCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ProjectPhoto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int ProfileId { get; set; }
        
    }
}