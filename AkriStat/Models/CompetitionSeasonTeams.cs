using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class CompetitionSeasonTeams
    {
        public string SeasonYear { get; set; }
        public int CompetitionID { get; set; }
        public int TeamID { get; set; }

        public virtual Competitions Competition { get; set; }
        public virtual Seasons SeasonYearNavigation { get; set; }
        public virtual Teams Team { get; set; }
    }
}
