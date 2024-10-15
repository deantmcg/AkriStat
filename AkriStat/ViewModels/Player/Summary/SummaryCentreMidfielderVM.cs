using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Summary
{
    public class SummaryCentreMidfielderVM
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double ChancesCreatedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double ChancesCreatedPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double XgassistedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double XgassistedPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double AssistsPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesIntoFinalThirdPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesIntoFinalThirdPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double YardsProgressiveCarriesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double YardsProgressiveCarriesPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesCompletedPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesCompletedPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulDribblesPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulDribblesPercentagePercentile { get; set; }
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
    }
}
