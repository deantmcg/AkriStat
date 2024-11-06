using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwSummaryTeamDefensive
    {
        public int? TeamID { get; set; }
        public string TeamName { get; set; }
        public string Season { get; set; }
        public int? MinutesPlayed { get; set; }
        public double ClearancesPerGame { get; set; }
        public double? ClearancesPerGamePercentile { get; set; }
        public double BlocksPerGame { get; set; }
        public double? BlocksPerGamePercentile { get; set; }
        public double SuccessfulPressuresPerGame { get; set; }
        public double? SuccessfulPressuresPerGamePercentile { get; set; }
        public double InterceptionsPerGame { get; set; }
        public double? InterceptionsPerGamePercentile { get; set; }
        public double TacklesWonPerGame { get; set; }
        public double? TacklesWonPerGamePercentile { get; set; }
        public double DribblersTackledPercentage { get; set; }
        public double? DribblersTackledPercentagePercentile { get; set; }
        public double AerialDualsWonPercentage { get; set; }
        public double? AerialDualsWonPercentagePerGamePercentile { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public double? PassesCompletedPercentagePerGamePercentile { get; set; }
    }
}
