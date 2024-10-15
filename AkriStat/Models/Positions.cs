using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Players = new HashSet<Players>();
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ColourCode { get; set; }
        public int ListOrder { get; set; }

        public virtual ICollection<Players> Players { get; set; }
    }
}
