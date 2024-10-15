using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player
{
    public class PlayerMatchLogVM
    {
        //public int MatchLogId { get; set; }
        public int MatchId { get; set; }
        [Display(ShortName = "Sn", Name = "Season")]
        public string Season { get; set; }
        //public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public DateTime Date { get; set; }
        public int CompetitionId { get; set; }
        //public int CompetitionTypeId { get; set; }
        public string CompetitionName { get; set; }
        //public string CompetitionLogoUrl { get; set; }
        public string Round { get; set; }
        public int TeamOneId { get; set; }
        public string TeamOneName { get; set; }
        public string TeamOneCrestUrl { get; set; }
        public int TeamTwoId { get; set; }
        public string TeamTwoName { get; set; }
        public string TeamTwoCrestUrl { get; set; }
        public bool IsNeutralVenue { get; set; }
        public int HomeTeamId { get; set; }
        public int TeamOneGoals { get; set; }
        public int TeamTwoGoals { get; set; }
        public bool Penalties { get; set; }
        public int? TeamOnePenalties { get; set; }
        public int? TeamTwoPenalties { get; set; }
        public int? WinningTeamId { get; set; }

        // Generates result string based on Winning Team ID and Team ID
        public string Result 
        {
            get
            {
                if (WinningTeamId == TeamId)
                    return "W";
                else if (!WinningTeamId.HasValue)
                    return "D";
                return "L";
            }
        }

        // Generates Score based on Team Goals
        public string Score
        {
            get
            {
                if (Penalties)
                {
                    return $"{TeamOneGoals} ({TeamOnePenalties.Value}) - {TeamTwoGoals} ({TeamTwoPenalties.Value})";
                }
                else
                {
                    return $"{TeamOneGoals} - {TeamTwoGoals}";
                }
            }
        }

        public bool Started { get; set; }
        public string PositionPlayed { get; set; }
        public int MinutesPlayed { get; set; }
        public bool YellowCard { get; set; }
        public bool RedCard { get; set; }
        public bool TwoYellowCards { get; set; }
        [Display(ShortName = "F", Name = "Fouls")]
        public int Fouls { get; set; }
        [Display(ShortName = "FD", Name = "Fouls Drawn")]
        public int FoulsDrawn { get; set; }
        [Display(ShortName = "Offs", Name = "Offside")]
        public int Offsides { get; set; }
        [Display(ShortName = "PK w", Name = "Penalty Kicks Won")]
        public int PenaltyKicksWon { get; set; }
        [Display(ShortName = "PK c", Name = "Penalty Kicks Conceded")]
        public int PenaltyKicksConceded { get; set; }
        [Display(ShortName = "OG", Name = "Own Goals")]
        public int OwnGoals { get; set; }
        [Display(ShortName = "LBR", Name = "Loose Balls Recovered")]
        public int LooseBallsRecovered { get; set; }
        [Display(ShortName = "ADW", Name = "Aerial Duals Won")]
        public int AerialDualsWon { get; set; }
        [Display(ShortName = "ADL", Name = "Aerial Duals Lost")]
        public int AerialDualsLost { get; set; }
        [Display(ShortName = "ADW%", Name = "Aerial Duals Won Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal AerialDualsWonPercentage { get; set; }
        [Display(ShortName = "PT", Name = "Players Tackled")]
        public int PlayersTackled { get; set; }
        [Display(ShortName = "TW", Name = "Tackles Won")]
        public int TacklesWon { get; set; }
        [Display(ShortName = "Tkl D1/3", Name = "Tackles Defensive Third")]
        public int TacklesDefensiveThird { get; set; }
        [Display(ShortName = "Tkl M1/3", Name = "Tackles Middle Third")]
        public int TacklesMiddleThird { get; set; }
        [Display(ShortName = "Tkl A1/3", Name = "Tackles Attacking Third")]
        public int TacklesAttackingThird { get; set; }
        [Display(ShortName = "Dr Tkl", Name = "Dribblers Tackled")]
        public int DribblersTackled { get; set; }
        [Display(ShortName = "Dr Past", Name = "Times Dribbled Past")]
        public int TimesDribbledPast { get; set; }
        [Display(ShortName = "Dr Con", Name = "Dribbles Contested")]
        public int DribblesContested { get; set; }
        [Display(ShortName = "Dr Tkl %", Name = "Dribblers Tackled Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal DribblersTackledPercentage { get; set; }
        [Display(ShortName = "Pr D1/3", Name = "Pressures Defensive Third")]
        public int PressuresDefensiveThird { get; set; }
        [Display(ShortName = "Pr M1/3", Name = "Pressures Middle Third")]
        public int PressuresMiddleThird { get; set; }
        [Display(ShortName = "Pr A1/3", Name = "Pressures Attacking Third")]
        public int PressuresAttackingThird { get; set; }
        [Display(ShortName = "Pr", Name = "Pressures")]
        public int Pressures { get; set; }
        [Display(ShortName = "Suc Pr", Name = "Successful Pressues")]
        public int SuccessfulPressures { get; set; }
        [Display(ShortName = "Suc Pr %", Name = "Successful Pressures "), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal SuccessfulPressuresPercentage { get; set; }
        [Display(ShortName = "S Blkd", Name = "Shots Blocked")]
        public int ShotsBlocked { get; set; }
        [Display(ShortName = "SoT Blkd", Name = "Shots on Target Blocked by Player")]
        public int ShotsOnTargetBlocked { get; set; }
        [Display(ShortName = "Ps Blkd", Name = "Passes Blocked by Player")]
        public int PassesBlocked { get; set; }
        [Display(ShortName = "Blk", Name = "Blocks by Player")]
        public int Blocks { get; set; }
        [Display(ShortName = "Tkl + Int", Name = "Players Tackled and Interceptions Made")]
        public int PlayersTackledAndInterceptions { get; set; }
        [Display(ShortName = "Int", Name = "Interceptions Made")]
        public int Interceptions { get; set; }
        [Display(ShortName = "Clr", Name = "Clearances Made")]
        public int Clearances { get; set; }
        [Display(ShortName = "Err Sht", Name = "Errors Leading to Shot")]
        public int ErrorsLeadingToShot { get; set; }
        [Display(ShortName = "Tc DPA", Name = "Touches Defensive Penalty Area")]
        public int TouchesDefensivePenaltyArea { get; set; }
        [Display(ShortName = "Tc D1/3", Name = "Touches Defensive Third")]
        public int TouchesDefensiveThird { get; set; }
        [Display(ShortName = "Tc M1/3", Name = "Touches Middle Third")]
        public int TouchesMiddleThird { get; set; }
        [Display(ShortName = "Tc A1/3", Name = "Touches Attacking Third")]
        public int TouchesAttackingThird { get; set; }
        [Display(ShortName = "Tc APA", Name = "Touches Attacking Penalty Area")]
        public int TouchesAttackingPenaltyArea { get; set; }
        [Display(ShortName = "Tc", Name = "Touches")]
        public int Touches { get; set; }
        [Display(ShortName = "LB Tc", Name = "Live Ball Touches")]
        public int LiveBallTouches { get; set; }
        [Display(ShortName = "Drb Att", Name = "Dribbles Attempted")]
        public int DribblesAttempted { get; set; }
        [Display(ShortName = "Suc Drb", Name = "Successful Dribbles")]
        public int SuccessfulDribbles { get; set; }
        [Display(ShortName = "Suc Drb %", Name = "Successful Dribbles Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal SuccessfulDribblesPercentage { get; set; }
        [Display(ShortName = "Pl Drb", Name = "Players Dribbled Past")]
        public int PlayersDribbledPast { get; set; }
        [Display(ShortName = "Ntmg", Name = "Nutmegs")]
        public int Nutmegs { get; set; }
        [Display(ShortName = "Car", Name = "Carries")]
        public int ControlledBallWithFeet { get; set; }
        [Display(ShortName = "Yd Car", Name = "Yards Carried")]
        public int YardsControlledWithFeet { get; set; }
        [Display(ShortName = "Yd Car+", Name = "Yards Carried Progressive")]
        public int YardsProgressiveControlledWithFeet { get; set; }
        [Display(ShortName = "ToP", Name = "Times player was Target of Pass")]
        public int WasTargetOfPass { get; set; }
        [Display(ShortName = "Pa Rcv", Name = "Passes Received")]
        public int PassesReceived { get; set; }
        [Display(ShortName = "Pa Rcv %", Name = "Passes Received Percentage")]
        public decimal PassesReceivedPercentage { get; set; }
        [Display(ShortName = "Mctrl", Name = "Miscontrols")]
        public int Miscontrols { get; set; }
        [Display(ShortName = "Disp", Name = "Dispossessed")]
        public int Dispossessed { get; set; }
        [Display(ShortName = "Pa Cmp", Name = "Passes Completed")]
        public int PassesCompleted { get; set; }
        [Display(ShortName = "Pa Att", Name = "Passes Attempted")]
        public int PassesAttempted { get; set; }
        [Display(ShortName = "Pa Cmp %", Name = "Passes Completed Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal PassesCompletedPercentage { get; set; }
        [Display(ShortName = "Yd Pa", Name = "Yards Passed")]
        public int YardsPassed { get; set; }
        [Display(ShortName = "Yd Pa+", Name = "Yards Passed Progressive")]
        public int YardsPassedProgressive { get; set; }
        [Display(ShortName = "Sh Pa C", Name = "Short Passes Completed")]
        public int ShortPassesCompleted { get; set; }
        [Display(ShortName = "Sh Pa A", Name = "Short Passes Attempted")]
        public int ShortPassesAttempted { get; set; }
        [Display(ShortName = "Sh Pa C %", Name = "Short Passes Completed Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal ShortPassesCompletedPercentage { get; set; }
        [Display(ShortName = "Md Pa C", Name = "Medium Passes Completed")]
        public int MediumPassesCompleted { get; set; }
        [Display(ShortName = "Md Pa A", Name = "Medium Passes Attempted")]
        public int MediumPassesAttempted { get; set; }
        [Display(ShortName = "Md Pa C %", Name = "Medium Passes Completed Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal MediumPassesCompletedPercentage { get; set; }
        [Display(ShortName = "Lg Pa C", Name = "Long Passes Completed")]
        public int LongPassesCompleted { get; set; }
        [Display(ShortName = "Lg Pa A", Name = "Long Passes Attempted")]
        public int LongPassesAttempted { get; set; }
        [Display(ShortName = "Lg Pa C %", Name = "Long Passes Completed Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal LongPassesCompletedPercentage { get; set; }
        [Display(ShortName = "A", Name = "Assists")]
        public int Assists { get; set; }
        [Display(ShortName = "xA", Name = "Expected Goals Assisted")]
        public decimal Xgassisted { get; set; }
        [Display(ShortName = "KP", Name = "Key Passes")]
        public int KeyPasses { get; set; }
        [Display(ShortName = "Pa F1/3", Name = "Passes into Final Third")]
        public int PassesIntoFinalThird { get; set; }
        [Display(ShortName = "Pa PA", Name = "Passes into Penalty Area")]
        public int PassesIntoPenaltyArea { get; set; }
        [Display(ShortName = "Cr PA", Name = "Crosses into Penalty Area")]
        public int CrossesIntoPenaltyArea { get; set; }
        [Display(ShortName = "Pa+", Name = "Progressive Passes")]
        public int ProgressivePasses { get; set; }
        [Display(ShortName = "Pa+ %", Name = "Progressive Passes Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal ProgressivePassesPercentage { get; set; }
        [Display(ShortName = "Pa LB", Name = "Passes Attempted Live Ball")]
        public int PassesAttemptedLiveBall { get; set; }
        [Display(ShortName = "Pa DB", Name = "Passes Attempted Dead Ball")]
        public int PassesAttemptedDeadBall { get; set; }
        [Display(ShortName = "Pa FK", Name = "Passes Attempted Free Kick")]
        public int PassesAttemptedFreeKick { get; set; }
        [Display(ShortName = "Pa TB", Name = "Passes Completed Through Ball")]
        public int PassesCompletedThroughBall { get; set; }
        [Display(ShortName = "Pa Pr", Name = "Passes Completed Under Pressure")]
        public int PassesCompletedUnderPressure { get; set; }
        [Display(ShortName = "Sw", Name = "Switches")]
        public int Switches { get; set; }
        [Display(ShortName = "Cr", Name = "Crosses")]
        public int Crosses { get; set; }
        [Display(ShortName = "CK", Name = "Corner Kicks")]
        public int CornerKicks { get; set; }
        [Display(ShortName = "CK I", Name = "Corner Kicks Inswinging")]
        public int CornerKicksInswinging { get; set; }
        [Display(ShortName = "CK O", Name = "Corner Kicks Outswinging")]
        public int CornerKicksOutswinging { get; set; }
        [Display(ShortName = "CK S", Name = "Corner Kicks Straight")]
        public int CornerKicksStraight { get; set; }
        [Display(ShortName = "Pa G", Name = "Ground Passes")]
        public int PassesGround { get; set; }
        [Display(ShortName = "Pa Lo", Name = "Low Passes (Below Shoulder)")]
        public int PassesLow { get; set; }
        [Display(ShortName = "Pa Hi", Name = "High Passes (Above Shoulder)")]
        public int PassesHigh { get; set; }
        [Display(ShortName = "Pa LF", Name = "Left Foot Passes")]
        public int PassesLeftFoot { get; set; }
        [Display(ShortName = "Pa RF", Name = "Right Foot Passes")]
        public int PassesRightFoot { get; set; }
        [Display(ShortName = "Pa Hd", Name = "Headed Passes")]
        public int PassesHeaded { get; set; }
        [Display(ShortName = "Pa Th", Name = "Passes from Throw-in")]
        public int PassesThrowIn { get; set; }
        [Display(ShortName = "Pa Ot", Name = "Passes (Other)")]
        public int PassesOther { get; set; }
        [Display(ShortName = "Pa Of", Name = "Passes Offside")]
        public int PassesOffside { get; set; }
        [Display(ShortName = "Pa OoB", Name = "Passes Out of Bounds")]
        public int PassesOutOfBounds { get; set; }
        [Display(ShortName = "Pa Int", Name = "Passes Intercepted by other Team")]
        public int PassesAttemptedIntercepted { get; set; }
        [Display(ShortName = "Pa Blk", Name = "Passes Blocked by other Team")]
        public int PassesAttemptedBlocked { get; set; }
        [Display(ShortName = "SCA", Name = "Actions Leading to Shot")]
        public int ShotCreatingActions { get; set; }
        [Display(ShortName = "SCA PLB", Name = "Live Ball Passes Leading to a Shot")]
        public int PassesCompletedLiveBallLeadingToShot { get; set; }
        [Display(ShortName = "SCA PDB", Name = "Dead Ball Passes Leading to a Shot")]
        public int PassesCompletedDeadBallLeadingToShot { get; set; }
        [Display(ShortName = "SCA Dr", Name = "Dribbles Leading to a Shot")]
        public int DribblesLeadingToShot { get; set; }
        [Display(ShortName = "SCA Sh", Name = "Shots Leading to another Shot")]
        public int ShotsLeadingToAnotherShot { get; set; }
        [Display(ShortName = "SCA Fl", Name = "Fouls Drawn Leading to a Shot")]
        public int FoulsDrawnLeadingToShot { get; set; }
        [Display(ShortName = "GCA", Name = "Actions Leading to a Goal")]
        public int GoalCreatingActions { get; set; }
        [Display(ShortName = "GCA PLB", Name = "Live Ball Passes Leading to a Goal")]
        public int PassesCompletedLiveBallLeadingToGoal { get; set; }
        [Display(ShortName = "GCA PDB", Name = "Dead Ball Passes Leading to a Goal")]
        public int PassesCompletedDeadBallLeadingToGoal { get; set; }
        [Display(ShortName = "GCA Dr", Name = "Dribbles Leading to a Goal")]
        public int DribblesLeadingToGoal { get; set; }
        [Display(ShortName = "GCA Sh", Name = "Shots Leading to a Goal")]
        public int ShotsLeadingToAnotherGoal { get; set; }
        [Display(ShortName = "GCA Fl", Name = "Fouls Drawn Leading to a Goal")]
        public int FoulsDrawnLeadingToGoal { get; set; }
        [Display(ShortName = "Opp OG", Name = "Actions Leading to an Opponent Own Goal")]
        public int ActionsLeadingToOpponentOwnGoal { get; set; }
        [Display(ShortName = "G", Name = "Goals")]
        public int Goals { get; set; }
        [Display(ShortName = "Sh", Name = "Shots")]
        public int Shots { get; set; }
        [Display(ShortName = "SoT", Name = "Shots on Target")]
        public int ShotsOnTarget { get; set; }
        [Display(ShortName = "SoT %", Name = "Shots on Target Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal ShotsOnTargetPercentage { get; set; }
        [Display(ShortName = "G/Sh", Name = "Goals per Shot"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal GoalsPerShot { get; set; }
        [Display(ShortName = "G/SoT", Name = "Goals per Shot on Target"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal GoalsPerShotOnTarget { get; set; }
        [Display(ShortName = "Sh FK", Name = "Shots from Free Kick")]
        public int ShotsFromFreeKick { get; set; }
        [Display(ShortName = "PK Sc", Name = "Penalty Kicks Scored")]
        public int PenaltyKicksMade { get; set; }
        [Display(ShortName = "PK Att", Name = "Penalty Kicks Attempted")]
        public int PenaltyKicksAttempted { get; set; }
        [Display(ShortName = "xG", Name = "Expected Goals"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Xg { get; set; }
        [Display(ShortName = "npxG", Name = "Non-Penalty Expected Goals"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal NonPenaltyXg { get; set; }
        [Display(ShortName = "npxG/Sh", Name = "Non-Penalty Expected Goals per Shot"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal NonPenaltyXgPerShot { get; set; }
        [Display(ShortName = "G-xG", Name = "Goals minus xG"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal GoalsMinusXg { get; set; }
        [Display(ShortName = "npG-xG", Name = "Non-Penalty Goals minus Expected Goals"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal NonPenaltyGoalsMinusXg { get; set; }
        [Display(ShortName = "SoTA", Name = "(GK) Shots on Target Faced")]
        public int ShotsOnTargetFaced { get; set; }
        [Display(ShortName = "GA", Name = "(GK) Goals Conceded")]
        public int GoalsConceded { get; set; }
        [Display(ShortName = "Sv", Name = "(GK) Shots Saved")]
        public int Saves { get; set; }
        [Display(ShortName = "Sv %", Name = "(GK) Shots Saved Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal SavesPercentage { get; set; }
        [Display(ShortName = "CS", Name = "(GK) Clean Sheet")]
        public bool CleanSheet { get; set; }
        [Display(ShortName = "psxG", Name = "(GK) Post Shot Expected Goals"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal PostShotXg { get; set; }
        [Display(ShortName = "PC >40", Name = "(GK) Passes Completed Over 40 Yards")]
        public int PassesCompletedOver40Yards { get; set; }
        [Display(ShortName = "PA >40", Name = "(GK) Passes Attempted Over 40 Yards")]
        public int PassesAttemptedOver40Yards { get; set; }
        [Display(ShortName = "PC >40 %", Name = "(GK) Passes Completed Over 40 Yards Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal PassesCompletedOver40YardsPercentage { get; set; }
        [Display(ShortName = "Thr", Name = "(GK) Throws Attempted")]
        public int ThrowsAttempted { get; set; }
        [Display(ShortName = "Pa >40", Name = "(GK) Passes Over 40 Yards Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal PassesOver40YardsPercentage { get; set; }
        [Display(ShortName = "Pa yd", Name = "(GK) Average Pass Length (yards)"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal AverageYardsPassLength { get; set; }
        [Display(ShortName = "GKA", Name = "(GK) Goal Kicks Attempted")]
        public int GoalKicksAttempted { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [Display(ShortName = "GKL %", Name = "(GK) Goal Kicks Launched Percentage")]
        public decimal GoalKicksLaunchedPercentage { get; set; }
        [Display(ShortName = "GKAvgL", Name = "(GK) Goal Kick Average Length (yards)"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal GoalKickAverageYards { get; set; }
        [Display(ShortName = "Opp Cr", Name = "(GK) Opponent Crosses Attempted")]
        public int OpponentCrossesAttempted { get; set; }
        [Display(ShortName = "Cr Stp", Name = "(GK) Opponent Crosses Stopped")]
        public int CrossesStopped { get; set; }
        [Display(ShortName = "Cr Stp %", Name = "(GK) Opponent Crosses Stopped Percentage"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal CrossesStoppedPercentage { get; set; }
        [Display(ShortName = "Def Act", Name = "(GK) Defensive Actions outside Penalty Area")]
        public int DefensiveActionsOutsidePenaltyArea { get; set; }
        [Display(ShortName = "Def Act Dist", Name = "(GK) Average Distance (yards) from Goal for Defensive Actions"), DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal AverageDistanceFromGoalForDefensiveActions { get; set; }
    }
}
