using AkriStat.Models;
using AkriStat.ViewModels.Administrator;
using System.Linq;

namespace AkriStat.MappingProfiles
{
    public class AdministratorProfile : AutoMapper.Profile
    {
        public AdministratorProfile()
        {
            CreateMap<AspNetUsers, UserIndexVM>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AspNetUserRoles.First().Role.Name))
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => src.AspNetUserRoles.First().AspNetUserRoleTeams.Count() > 0 ? src.AspNetUserRoles.First().AspNetUserRoleTeams.First().Team.Name : "Freelance"));

            CreateMap<AspNetUsers, UserEditVM>();

            CreateMap<UserEditVM, AspNetUsers>();
        }
    }
}
