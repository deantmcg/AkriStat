using AkriStat.Models;
using AkriStat.ViewModels.Search;

namespace AkriStat.MappingProfiles
{
    public class SearchProfile : AutoMapper.Profile
    {
        public SearchProfile()
        {
            CreateMap<vwSummariesAdvancedSearch, AdvancedSearchResultVM>();

            CreateMap<Players, StandardSearchResultVM>()
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.FacePictureUrl))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Code))
                .ForMember(dest => dest.NationalityFlagUrl, opt => opt.MapFrom(src => src.Nationality.FlagUrl));
        }
    }
}
