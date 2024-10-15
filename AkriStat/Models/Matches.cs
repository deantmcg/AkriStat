using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Matches
    {
        public Matches()
        {
            PlayerMatchLogs = new HashSet<PlayerMatchLogs>();
        }

        public int ID { get; set; }
        public string Season { get; set; }
        public DateTime Date { get; set; }
        public int CompetitionID { get; set; }
        public string Round { get; set; }
        public int TeamOneID { get; set; }
        public int TeamTwoID { get; set; }
        public bool IsNeutralVenue { get; set; }
        public int? HomeTeamID { get; set; }
        public int TeamOneGoals { get; set; }
        public int TeamTwoGoals { get; set; }
        public bool Penalties { get; set; }
        public int? TeamOnePenalties { get; set; }
        public int? TeamTwoPenalties { get; set; }
        public int? WinningTeamID { get; set; }

        public virtual Competitions Competition { get; set; }
        public virtual Teams HomeTeam { get; set; }
        public virtual Seasons SeasonNavigation { get; set; }
        public virtual Teams TeamOne { get; set; }
        public virtual Teams TeamTwo { get; set; }
        public virtual Teams WinningTeam { get; set; }
        public virtual ICollection<PlayerMatchLogs> PlayerMatchLogs { get; set; }
    }
}
