using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryKeepers
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public double GkShotsOnTargetFacedPer90 { get; set; }
        public double? ShotsOnTargetFacedPer90Percentile { get; set; }
        public double GkPostShotXGPer90 { get; set; }
        public double? PostShotXGPer90Percentile { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public double? PassesCompletedPercentagePercentile { get; set; }
        public double GkPassesAttemptedOver40YardsPercentage { get; set; }
        public double? PassesAttemptedOver40YardsPercentagePercentile { get; set; }
        public double GkOpponentCrossesStoppedPercentage { get; set; }
        public double? OpponentCrossesStoppedPercentagePercentile { get; set; }
        public decimal? GkAverageGoalKicksLaunchedPercentage { get; set; }
        public double? AverageGoalKicksLaunchedPercentagePercentile { get; set; }
        public double GkSavesPer90 { get; set; }
        public double? SavesPer90Percentile { get; set; }
    }
}
