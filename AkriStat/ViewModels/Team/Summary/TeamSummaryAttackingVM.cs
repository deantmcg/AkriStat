using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Team.Summary
{
    public class TeamSummaryAttackingVM
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string Season { get; set; }
        public int MinutesPlayed { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double ChancesCreatedPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double ChancesCreatedPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double XGAssistedPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double XGAssistedPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double XGPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double XGPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double CrossesPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double CrossesPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulDribblesPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulDribblesPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulDribblesPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulDribblesPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesIntoFinalThirdPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesIntoFinalThirdPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double YardsProgressiveCarriesPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double YardsProgressiveCarriesPerGamePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesCompletedPerGame { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesCompletedPerGamePercentile { get; set; }

    }
}
