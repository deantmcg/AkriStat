using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class ScrapeBatchJobs
    {
        public int ID { get; set; }
        public int ScrapeBatchID { get; set; }
        public string QueryFbRefID { get; set; }
        public int? QueryPlayerID { get; set; }
        public bool? Successful { get; set; }
        public int? ImportID { get; set; }
        public string ErrorMessage { get; set; }
        public string Season { get; set; }

        public virtual MatchLogImports Import { get; set; }
        public virtual Players QueryPlayer { get; set; }
        public virtual ScrapeBatches ScrapeBatch { get; set; }
        public virtual Seasons SeasonNavigation { get; set; }
    }
}
