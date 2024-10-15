using AkriStat.Models;
using AkriStat.ViewModels.Dashboard;

namespace AkriStat.MappingProfiles
{
    public class DashboardProfile : AutoMapper.Profile
    {
        public DashboardProfile()
        {
            CreateMap<PlayerMatchLogSummaries, TopPerformersVM>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.PlayerID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PlayerName));

            CreateMap<TeamMatchLogSummaries, TopPerformersVM>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.TeamID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TeamName));
        }
    }
}
