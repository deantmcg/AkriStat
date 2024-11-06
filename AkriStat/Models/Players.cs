using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Players
    {
        public Players()
        {
            PlayerMatchLogs = new HashSet<PlayerMatchLogs>();
            ShortlistedPlayers = new HashSet<ShortlistedPlayers>();
        }

        public int ID { get; set; }
        public string FbRefID { get; set; }
        public string TransfermarktID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string FullName { get; set; }
        public string NormalizedFullName { get; set; }
        public string FacePictureUrl { get; set; }
        public int PositionID { get; set; }
        public string Footed { get; set; }
        public decimal? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityID { get; set; }
        public int? SecondNationalityID { get; set; }
        public string PlaceOfBirth { get; set; }
        public decimal? Value { get; set; }
        public int? CurrentTeamID { get; set; }
        public decimal? WeeklyWage { get; set; }
        public DateTime? ContractExpiry { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string MarketValueJson { get; set; }

        public virtual Teams CurrentTeam { get; set; }
        public virtual Countries Nationality { get; set; }
        public virtual Positions Position { get; set; }
        public virtual Countries SecondNationality { get; set; }
        public virtual ICollection<PlayerMatchLogs> PlayerMatchLogs { get; set; }
        public virtual ICollection<ShortlistedPlayers> ShortlistedPlayers { get; set; }
    }
}
