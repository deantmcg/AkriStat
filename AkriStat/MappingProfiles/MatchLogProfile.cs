using AkriStat.Models;
using AkriStat.ViewModels.Player;

namespace AkriStat.MappingProfiles
{
    public class MatchLogProfile : AutoMapper.Profile
    {
        public MatchLogProfile()
        {
            CreateMap<vwCombinedMatchLogs, PlayerMatchLogVM>();
        }
    }
}
