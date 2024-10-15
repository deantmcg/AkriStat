using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class TeamTypes
    {
        public TeamTypes()
        {
            Teams = new HashSet<Teams>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }
    }
}
