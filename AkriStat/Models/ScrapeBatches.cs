using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class ScrapeBatches
    {
        public ScrapeBatches()
        {
            ScrapeBatchJobs = new HashSet<ScrapeBatchJobs>();
        }

        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AspNetUsers CreatedByNavigation { get; set; }
        public virtual ICollection<ScrapeBatchJobs> ScrapeBatchJobs { get; set; }
    }
}
