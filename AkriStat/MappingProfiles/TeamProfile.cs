using AkriStat.Models;
using AkriStat.ViewModels.Team;
using AkriStat.ViewModels.Team.Summary;
using System.Linq;

namespace AkriStat.MappingProfiles
{
    public class TeamProfile : AutoMapper.Profile
    {
        public TeamProfile()
        {
            CreateMap<Teams, TeamDetailsVM>()
                .ForMember(dest => dest.NationName, opt => opt.MapFrom(src => src.Nation.Name))
                .ForMember(dest => dest.NationFlagUrl, opt => opt.MapFrom(src => src.Nation.FlagUrl))
                .ForMember(dest => dest.CurrentLeagueID, opt => opt.MapFrom(src => src.CompetitionSeasonTeams
                                                                                      .Where(x => x.SeasonYear.Equals(Constants.SiteProperties.CurrentSeason)
                                                                                             && x.Competition.CompetitionTypeID == 1)
                                                                                      .First().CompetitionID))
                .ForMember(dest => dest.CurrentLeagueName, opt => opt.MapFrom(src => src.CompetitionSeasonTeams
                                                                                      .Where(x => x.SeasonYear.Equals(Constants.SiteProperties.CurrentSeason)
                                                                                             && x.Competition.CompetitionTypeID == 1)
                                                                                      .First().Competition.Name))
                /*.ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players.ToList()))*/
                .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.Players.Select(x => x.Value).Sum().Value));

            CreateMap<Teams, TeamEditVM>();
            CreateMap<TeamEditVM, Teams>();

            // Graphs
            CreateMap<vwSummaryTeamAttacking, TeamSummaryAttackingVM>();
            CreateMap<vwSummaryTeamDefensive, TeamSummaryDefensiveVM>();
        }
    }
}
