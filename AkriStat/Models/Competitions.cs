using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Competitions
    {
        public Competitions()
        {
            CompetitionSeasonTeams = new HashSet<CompetitionSeasonTeams>();
            Matches = new HashSet<Matches>();
        }

        public int ID { get; set; }
        public string FbRefID { get; set; }
        public string Name { get; set; }
        public int? CompetitionTypeID { get; set; }
        public int? LeagueTier { get; set; }
        public int? NationID { get; set; }

        public virtual CompetitionTypes CompetitionType { get; set; }
        public virtual Countries Nation { get; set; }
        public virtual ICollection<CompetitionSeasonTeams> CompetitionSeasonTeams { get; set; }
        public virtual ICollection<Matches> Matches { get; set; }
    }
}
