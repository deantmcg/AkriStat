using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class MatchLogImports
    {
        public MatchLogImports()
        {
            ScrapeBatchJobs = new HashSet<ScrapeBatchJobs>();
        }

        public int ID { get; set; }
        public int PlayerID { get; set; }
        public DateTime DateScraped { get; set; }
        public bool Executed { get; set; }
        public DateTime? DateExecuted { get; set; }
        public bool? Success { get; set; }
        public string ErrorMessage { get; set; }

        public virtual Players Player { get; set; }
        public virtual MatchLogImportFiles MatchLogImportFiles { get; set; }
        public virtual ICollection<ScrapeBatchJobs> ScrapeBatchJobs { get; set; }
    }
}
