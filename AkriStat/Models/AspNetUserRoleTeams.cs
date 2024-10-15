using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class AspNetUserRoleTeams
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public int TeamId { get; set; }

        public virtual AspNetUserRoles AspNetUserRoles { get; set; }
        public virtual Teams Team { get; set; }
    }
}
