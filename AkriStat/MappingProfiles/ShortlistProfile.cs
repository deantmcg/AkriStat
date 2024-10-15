using AkriStat.Models;
using AkriStat.ViewModels.Shortlist;

namespace AkriStat.MappingProfiles
{
    public class ShortlistProfile : AutoMapper.Profile
    {
        public ShortlistProfile()
        {
            CreateMap<Shortlists, ShortlistIndexVM>()
                .ForMember(dest => dest.PlayerCount, opt => opt.MapFrom(x => x.ShortlistedPlayers.Count));

            CreateMap<Shortlists, ShortlistDetailsVM>()
                .ForMember(dest => dest.Heading, opt => opt.MapFrom(x => x.Name));

            CreateMap<Players, ShortlistedPlayerLineVM>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Code))
                .ForMember(dest => dest.Age, opt => opt.Ignore());
        }
    }
}
