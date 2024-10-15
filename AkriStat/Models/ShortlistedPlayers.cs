using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class ShortlistedPlayers
    {
        public int ShortlistID { get; set; }
        public int PlayerID { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Players Player { get; set; }
        public virtual Shortlists Shortlist { get; set; }
    }
}
