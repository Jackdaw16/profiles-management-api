using AutoMapper;
using ProfileManagementApi.Models;
using ProfileManagementApi.Models.ViewModels;

namespace ProfileManagementApi
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            /*Profiles*/
            CreateMap<Profiles, ProfileResponse>();
            CreateMap<Profiles, ProfileCreate>();
            CreateMap<ProfileCreate, Profiles>();
            
            /*Projects*/
            CreateMap<Projects, ProjectsResponse>();
            CreateMap<Projects, ProjectsCreate>();
            CreateMap<ProjectsCreate, Projects>();
        }
    }
}