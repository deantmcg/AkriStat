using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Teams
    {
        public Teams()
        {
            AspNetUserRoleTeams = new HashSet<AspNetUserRoleTeams>();
            CompetitionSeasonTeams = new HashSet<CompetitionSeasonTeams>();
            MatchesHomeTeam = new HashSet<Matches>();
            MatchesTeamOne = new HashSet<Matches>();
            MatchesTeamTwo = new HashSet<Matches>();
            MatchesWinningTeam = new HashSet<Matches>();
            PlayerMatchLogs = new HashSet<PlayerMatchLogs>();
            PlayerTeamsHistoryParentClubNavigation = new HashSet<PlayerTeamsHistory>();
            PlayerTeamsHistoryTeam = new HashSet<PlayerTeamsHistory>();
            Players = new HashSet<Players>();
        }

        public int ID { get; set; }
        public string FbRefID { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string FullName { get; set; }
        public string NormalizedFullName { get; set; }
        public int? YearFounded { get; set; }
        public string StadiumName { get; set; }
        public string Address { get; set; }
        public int NationID { get; set; }
        public int TeamTypeID { get; set; }
        public string ColourCode1 { get; set; }
        public string ColourCode2 { get; set; }
        public string ColourCode3 { get; set; }

        public virtual Countries Nation { get; set; }
        public virtual TeamTypes TeamType { get; set; }
        public virtual ICollection<AspNetUserRoleTeams> AspNetUserRoleTeams { get; set; }
        public virtual ICollection<CompetitionSeasonTeams> CompetitionSeasonTeams { get; set; }
        public virtual ICollection<Matches> MatchesHomeTeam { get; set; }
        public virtual ICollection<Matches> MatchesTeamOne { get; set; }
        public virtual ICollection<Matches> MatchesTeamTwo { get; set; }
        public virtual ICollection<Matches> MatchesWinningTeam { get; set; }
        public virtual ICollection<PlayerMatchLogs> PlayerMatchLogs { get; set; }
        public virtual ICollection<PlayerTeamsHistory> PlayerTeamsHistoryParentClubNavigation { get; set; }
        public virtual ICollection<PlayerTeamsHistory> PlayerTeamsHistoryTeam { get; set; }
        public virtual ICollection<Players> Players { get; set; }
    }
}
