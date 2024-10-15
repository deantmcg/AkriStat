using AkriStat.Models;
using AkriStat.ViewModels.League;

namespace AkriStat.MappingProfiles
{
    public class LeagueProfile : AutoMapper.Profile
    {
        public LeagueProfile()
        {
            CreateMap<LeagueTableLines, LeagueTableLineVM>();
        }
    }
}
