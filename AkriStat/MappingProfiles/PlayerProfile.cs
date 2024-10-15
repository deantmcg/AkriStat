using AkriStat.Models;
using AkriStat.ViewModels.Player;
using AkriStat.ViewModels.Player.Summary;
using AkriStat.ViewModels.Search;

namespace AkriStat.MappingProfiles
{
    public class PlayerProfile : AutoMapper.Profile
    {
        public PlayerProfile()
        {
            CreateMap<Players, PlayerDetailsVM>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(x => x.Position.Code))
                .ForMember(dest => dest.PositionDisplay, opt => opt.MapFrom(x => x.Position.Name))
                .ForMember(dest => dest.PositionColourCode, opt => opt.MapFrom(x => x.Position.ColourCode))
                .ForMember(dest => dest.Club, opt => opt.MapFrom(x => x.CurrentTeam.Name))
                .ForMember(dest => dest.ClubID, opt => opt.MapFrom(x => x.CurrentTeam.ID))
                .ForMember(dest => dest.WeightKg, opt => opt.MapFrom(x => x.Weight))
                .ForMember(dest => dest.HeightCm, opt => opt.MapFrom(x => x.Height))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(x => x.Nationality.Name))
                .ForMember(dest => dest.NationalityFlag, opt => opt.MapFrom(x => x.Nationality.FlagUrl))
                .ForMember(dest => dest.SecondNationality, opt => opt.MapFrom(x => x.SecondNationality.Name))
                .ForMember(dest => dest.SecondNationalityFlag, opt => opt.MapFrom(x => x.SecondNationality.FlagUrl));

            CreateMap<Players, PlayerIndexVM>();
            CreateMap<PlayerMatchLogSummaries, PlayerIndexVM>();

            CreateMap<Players, PlayerEditVM>();
            CreateMap<PlayerEditVM, Players>();

            // Bars
            CreateMap<PlayerMatchLogSummaries, BarsVM>();

            // Full Match Log
            CreateMap<Players, PlayerMatchLogFullVM>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(x => x.Position.Code))
                .ForMember(dest => dest.PositionDisplay, opt => opt.MapFrom(x => x.Position.Name));
        }
    }
}
