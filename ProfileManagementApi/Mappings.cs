using AutoMapper;
using ProfileManagementApi.Models;
using ProfileManagementApi.Models.ViewModels;

namespace ProfileManagementApi
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<Profiles, ProfileResponse>();
            CreateMap<Profiles, ProfileCreate>();
            CreateMap<ProfileCreate, Profiles>();
        }
    }
}