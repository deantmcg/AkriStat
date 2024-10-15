using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryFullBacks
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public double XGAssistedPer90 { get; set; }
        public double? XGAssistedPer90Percentile { get; set; }
        public double PassesIntoFinalThirdPer90 { get; set; }
        public double? PassesIntoFinalThirdPer90Percentile { get; set; }
        public double YardsProgressiveCarriesPer90 { get; set; }
        public double? YardsProgressiveCarriesPer90Percentile { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public double? PassesCompletedPercentagePercentile { get; set; }
        public double SuccessfulDribblesPer90 { get; set; }
        public double? SuccessfulDribblesPer90Percentile { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public double? SuccessfulDribblesPercentagePercentile { get; set; }
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
    }
}
