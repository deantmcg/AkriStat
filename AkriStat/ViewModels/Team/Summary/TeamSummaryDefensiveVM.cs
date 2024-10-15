using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Team.Summary
{
    public class TeamSummaryDefensiveVM
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Season { get; set; }
        public int MinutesPlayed { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double ClearancesPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double ClearancesPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double BlocksPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double BlocksPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulPressuresPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulPressuresPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double InterceptionsPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double InterceptionsPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double TacklesWonPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double TacklesWonPerGamePercentile { get; set; }
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
