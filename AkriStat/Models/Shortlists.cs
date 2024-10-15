using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Shortlists
    {
        public Shortlists()
        {
            ShortlistedPlayers = new HashSet<ShortlistedPlayers>();
        }

        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDefault { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<ShortlistedPlayers> ShortlistedPlayers { get; set; }
    }
}
