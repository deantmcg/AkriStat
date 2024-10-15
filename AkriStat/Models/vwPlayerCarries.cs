using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwPlayerCarries
    {
        public int PlayerID { get; set; }
        public string Season { get; set; }
        public int? MinutesPlayed { get; set; }
        public string Name { get; set; }
        public double CarriesPer90 { get; set; }
        public double? YardsPerCarry { get; set; }
    }
}
