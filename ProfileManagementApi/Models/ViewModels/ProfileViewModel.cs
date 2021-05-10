using System;
using Microsoft.AspNetCore.Http;

namespace ProfileManagementApi.Models.ViewModels
{
    public class ProfileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProfileCreate
    {
        public int Name { get; set; }
        public string Description { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}