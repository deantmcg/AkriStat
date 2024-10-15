using AkriStat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AkriStat.ViewModels.Player
{
    public class PlayerMatchLogFullVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PositionDisplay { get; set; }
        public List<PlayerMatchLogVM> MatchLogs { get; set; }

        public List<string> ColumnsNotAutoDisplayed
        {
            get
            {
                return new List<string>()
                {
                    "MatchId",
                    "Season",
                    "TeamId",
                    "Date",
                    "CompetitionId",
                    "CompetitionName",
                    "Round",
                    "Result",
                    "Score",
                    "Started",
                    "PositionPlayed",
                    "MinutesPlayed",
                    "TeamOneId",
                    "TeamOneName",
                    "TeamOneCrestUrl",
                    "TeamTwoId",
                    "TeamTwoName",
                    "TeamTwoCrestUrl",
                    "IsNeutralVenue",
                    "HomeTeamId",
                    "TeamOneGoals",
                    "TeamTwoGoals",
                    "Penalties",
                    "TeamOnePenalties",
                    "TeamTwoPenalties",
                    "WinningTeamId",
                    "YellowCard",
                    "RedCard",
                    "TwoYellowCards"
                };
            }
        }

        public List<SelectListItem> SeasonsSelectList { get; set; }
    }
}
