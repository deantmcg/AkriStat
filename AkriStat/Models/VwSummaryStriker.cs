using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryStriker
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public int? MinutesPlayed { get; set; }
        public double ChancesCreatedPer90 { get; set; }
        public double? ChancesCreatedPer90Percentile { get; set; }
        public double TouchesAttackingPenaltyAreaPer90 { get; set; }
        public double? TouchesAttackingPenaltyAreaPer90Percentile { get; set; }
        public double ShotsOnTargetPer90 { get; set; }
        public double? ShotsOnTargetPer90Percentile { get; set; }
        public double SuccessfulDribblesPer90 { get; set; }
        public double? SuccessfulDribblesPer90Percentile { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public double? SuccessfulDribblesPercentagePercentile { get; set; }
        public double NonPenaltyXGPerShot { get; set; }
        public double? NonPenaltyXGPerShotPercentile { get; set; }
        public double NonPenaltyXGPer90 { get; set; }
        public double? NonPenaltyXGPer90Percentile { get; set; }
        public double XGAssistedPer90 { get; set; }
        public double? XGAssistedPer90Percentile { get; set; }
        public int? Goals { get; set; }
        public double? GoalsPercentile { get; set; }
    }
}
