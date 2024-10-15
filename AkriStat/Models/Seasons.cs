using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Seasons
    {
        public Seasons()
        {
            CompetitionSeasonTeams = new HashSet<CompetitionSeasonTeams>();
            Matches = new HashSet<Matches>();
            ScrapeBatchJobs = new HashSet<ScrapeBatchJobs>();
        }

        public string Year { get; set; }

        public virtual ICollection<CompetitionSeasonTeams> CompetitionSeasonTeams { get; set; }
        public virtual ICollection<Matches> Matches { get; set; }
        public virtual ICollection<ScrapeBatchJobs> ScrapeBatchJobs { get; set; }
    }
}
