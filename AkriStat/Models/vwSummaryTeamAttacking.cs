using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryTeamAttacking
    {
        public int? TeamID { get; set; }
        public string TeamName { get; set; }
        public string Season { get; set; }
        public int? MinutesPlayed { get; set; }
        public double ChancesCreatedPerGame { get; set; }
        public double? ChancesCreatedPerGamePercentile { get; set; }
        public double XGAssistedPerGame { get; set; }
        public double? XGAssistedPerGamePercentile { get; set; }
        public double XGPerGame { get; set; }
        public double? XGPerGamePercentile { get; set; }
        public double CrossesPerGame { get; set; }
        public double? CrossesPerGamePercentile { get; set; }
        public double SuccessfulDribblesPerGame { get; set; }
        public double? SuccessfulDribblesPerGamePercentile { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public double? SuccessfulDribblesPercentagePercentile { get; set; }
        public double PassesIntoFinalThirdPerGame { get; set; }
        public double? PassesIntoFinalThirdPerGamePercentile { get; set; }
        public double YardsProgressiveCarriesPerGame { get; set; }
        public double? YardsProgressiveCarriesPerGamePercentile { get; set; }
        public double PassesCompletedPerGame { get; set; }
        public double? PassesCompletedPerGamePercentile { get; set; }
    }
}
