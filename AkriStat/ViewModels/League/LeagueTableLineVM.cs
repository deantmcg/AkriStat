using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.League
{
    public class LeagueTableLineVM
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string CrestIcon { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PointsPerGame { get; set; }
    }
}
