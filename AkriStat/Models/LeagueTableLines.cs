using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class LeagueTableLines
    {
        public string Season { get; set; }
        public int? LeagueID { get; set; }
        public int? TeamID { get; set; }
        public string Name { get; set; }
        public int? GamesPlayed { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Losses { get; set; }
        public int? GoalsScored { get; set; }
        public int? GoalsConceded { get; set; }
        public int? GoalDifference { get; set; }
        public int? Points { get; set; }
        public double? PointsPerGame { get; set; }
    }
}
