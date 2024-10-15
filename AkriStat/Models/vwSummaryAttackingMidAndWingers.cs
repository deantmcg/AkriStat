using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryAttackingMidAndWingers
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public int? MinutesPlayed { get; set; }
        public double ChancesCreatedPer90 { get; set; }
        public double? ChancesCreatedPer90Percentile { get; set; }
        public double XGAssistedPer90 { get; set; }
        public double? XGAssistedPer90Percentile { get; set; }
        public double XGPer90 { get; set; }
        public double? XGPer90Percentile { get; set; }
        public double CrossesPer90 { get; set; }
        public double? CrossesPer90Percentile { get; set; }
        public double SuccessfulDribblesPer90 { get; set; }
        public double? SuccessfulDribblesPer90Percentile { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public double? SuccessfulDribblesPercentagePercentile { get; set; }
        public double PassesIntoFinalThirdPer90 { get; set; }
        public double? PassesIntoFinalThirdPer90Percentile { get; set; }
        public double YardsProgressiveCarriesPer90 { get; set; }
        public double? YardsProgressiveCarriesPer90Percentile { get; set; }
        public double PassesCompletedPer90 { get; set; }
        public double? PassesCompletedPer90Percentile { get; set; }
    }
}
