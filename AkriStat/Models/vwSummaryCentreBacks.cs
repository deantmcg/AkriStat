using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryCentreBacks
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public double ClearancesPer90 { get; set; }
        public double? ClearancesPer90Percentile { get; set; }
        public double BlocksPer90 { get; set; }
        public double? BlocksPer90Percentile { get; set; }
        public double SuccessfulPressuresPer90 { get; set; }
        public double? SuccessfulPressuresPer90Percentile { get; set; }
        public double InterceptionsPer90 { get; set; }
        public double? InterceptionsPer90Percentile { get; set; }
        public double TacklesWonPer90 { get; set; }
        public double? TacklesWonPer90Percentile { get; set; }
        public double DribblersTackledPercentage { get; set; }
        public double? DribblersTackledPercentagePercentile { get; set; }
        public double AerialDualsWonPercentage { get; set; }
        public double? AerialDualsWonPercentagePercentile { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public double? PassesCompletedPercentagePercentile { get; set; }
    }
}
