using AkriStat.Helpers;
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
                .ForMember(dest => dest.Team, opt => opt.MapFrom(src => GetUserTeamName(src)));

            CreateMap<AspNetUsers, UserEditVM>();

            CreateMap<UserEditVM, AspNetUsers>();
        }

        private string GetUserTeamName(AspNetUsers user)
        {
            if (user.IsAdmin() || user.IsStandardUser())
            {
                return string.Empty;
            }

            if (user.WorksForTeam())
            {
                return user.AspNetUserRoles.First().AspNetUserRoleTeams.First().Team.Name;
            }

            return "Freelance";
        }
    }
}
