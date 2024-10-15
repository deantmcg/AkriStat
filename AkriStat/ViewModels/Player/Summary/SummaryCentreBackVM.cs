using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Summary
{
    public class SummaryCentreBackVM
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double ClearancesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double ClearancesPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double BlocksPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double BlocksPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulPressuresPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulPressuresPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double InterceptionsPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double InterceptionsPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double TacklesWonPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double TacklesWonPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double DribblersTackledPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double DribblersTackledPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double AerialDualsWonPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double AerialDualsWonPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesCompletedPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesCompletedPercentagePercentile { get; set; }
    }
}
