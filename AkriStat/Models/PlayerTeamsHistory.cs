using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class PlayerTeamsHistory
    {
        public int ID { get; set; }
        public int TeamID { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime? DateLeft { get; set; }
        public bool? IsLoan { get; set; }
        public int? ParentClub { get; set; }

        public virtual Teams ParentClubNavigation { get; set; }
        public virtual Teams Team { get; set; }
    }
}
