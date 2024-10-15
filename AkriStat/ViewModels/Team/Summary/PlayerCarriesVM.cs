using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.ViewModels.Team.Summary
{
    public class PlayerCarriesVM
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public double CarriesPer90 { get; set; }
        public double YardsPerCarry { get; set; }
    }
}
