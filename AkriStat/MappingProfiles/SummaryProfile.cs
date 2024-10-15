using AkriStat.Models;
using AkriStat.ViewModels.Player.Summary;

namespace AkriStat.MappingProfiles
{
    public class SummaryProfile : AutoMapper.Profile
    {
        public SummaryProfile()
        {
            CreateMap<vwSummaryKeepers, SummaryKeeperVM>();
            CreateMap<vwSummaryFullBacks, SummaryFullBackVM>();
            CreateMap<vwSummaryCentreBacks, SummaryCentreBackVM>();
            CreateMap<vwSummaryCentreMidfielders, SummaryCentreMidfielderVM>();
            CreateMap<vwSummaryAttackingMidAndWingers, SummaryAttackingMidAndWingerVM>();
            CreateMap<vwSummaryStriker, SummaryStrikerVM>();
        }
    }
}
