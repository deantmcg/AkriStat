using AkriStat.Models;
using AkriStat.ViewModels.Account;
using System.Linq;

namespace AkriStat.MappingProfiles
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<AspNetUsers, AccountDetailsVM>()
                .ForMember(dest => dest.FavouriteTeamId, opt => opt.MapFrom(src => 
                    src.AspNetUserClaims.FirstOrDefault(x => x.ClaimType.Equals(Constants.ASClaimTypes.FavouriteTeam)).ClaimValue));

            CreateMap<AccountDetailsVM, AspNetUsers>();
        }
    }
}
