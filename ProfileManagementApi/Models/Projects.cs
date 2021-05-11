using System;

namespace ProfileManagementApi.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectPhoto { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int ProfilesId { get; set; }
        public Profiles Profiles { get; set; }
    }
}