using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Competitions = new HashSet<Competitions>();
            PlayersNationality = new HashSet<Players>();
            PlayersSecondNationality = new HashSet<Players>();
            Teams = new HashSet<Teams>();
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FlagUrl { get; set; }

        public virtual ICollection<Competitions> Competitions { get; set; }
        public virtual ICollection<Players> PlayersNationality { get; set; }
        public virtual ICollection<Players> PlayersSecondNationality { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
