using AutoMapper;
using ProfileManagementApi.Models;
using ProfileManagementApi.Models.ViewModels;

namespace ProfileManagementApi
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<Profile, ProfileResponse>();
            CreateMap<Profile, ProfileCreate>();
            CreateMap<ProfileCreate, Profiles>();
        }
    }
}