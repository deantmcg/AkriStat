using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Summary
{
    public class SummaryKeeperVM
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double GkShotsOnTargetFacedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? ShotsOnTargetFacedPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double GkPostShotXGPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? PostShotXGPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesCompletedPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? PassesCompletedPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double GkPassesAttemptedOver40YardsPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? PassesAttemptedOver40YardsPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double GkOpponentCrossesStoppedPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? OpponentCrossesStoppedPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal? GkAverageGoalKicksLaunchedPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? AverageGoalKicksLaunchedPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double GkSavesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? SavesPer90Percentile { get; set; }
    }
}
