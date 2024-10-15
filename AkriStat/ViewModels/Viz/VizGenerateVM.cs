﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Viz
{
    public class VizGenerateVM
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Subtitle { get; set; }

        [Display(Name = "Visualisation Type"), Required]
        public string VizType { get; set; }

        [Display(Name = "Stacked"), Required]
        public bool Stacked { get; set; }

        [Display(Name = "Data Points"), Required]
        public List<string> DataPoints { get; set; }

        [Display(Name = "Players")]
        public List<int> PlayerIds { get; set; }

        [Display(Name = "Min. Minutes Played"), Range(1, 9999)]
        public int MinutesPlayed { get; set; } = 400;

        public bool? Success { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public List<SelectListItem> PlayersSelectList { get; set; }

        public List<SelectListItem> VizTypeSelectList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "line", Text = "Line Graph" },
                    new SelectListItem() { Value = "bar", Text = "Bar Chart" },
                    new SelectListItem() { Value = "column", Text = "Column Chart" },
                    new SelectListItem() { Value = "pie", Text = "Pie Chart" },
                    new SelectListItem() { Value = "scatter", Text = "Scatter Plot" },
                    new SelectListItem() { Value = "radar", Text = "Radar Chart" },
                };
            }
        }

        public List<SelectListItem> DataSelectList
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem() { Value = "MinutesPlayed", Text = "Minutes Played" },
                    new SelectListItem() { Value = "Goals", Text = "Goals" },
                    new SelectListItem() { Value = "GoalsPer90", Text = "Goals per 90" },
                    new SelectListItem() { Value = "Shots", Text = "Shots" },
                    new SelectListItem() { Value = "ShotsPer90", Text = "Shots per 90" },
                    new SelectListItem() { Value = "ShotsOnTarget", Text = "Shots on Target" },
                    new SelectListItem() { Value = "ShotsOnTargetPer90", Text = "Shots on Target per 90" },
                    new SelectListItem() { Value = "ShotsOnTargetPercentage", Text = "Shots on Target %" },
                    new SelectListItem() { Value = "AverageShotsOnTargetPercentage", Text = "Average Shots on Target %" },
                    new SelectListItem() { Value = "ShotsPerTouch", Text = "Shots per Touch" },
                    new SelectListItem() { Value = "GoalsPerShot", Text = "Goals per Shot" },
                    new SelectListItem() { Value = "PenaltyKicksMade", Text = "Penalties Scored" },
                    new SelectListItem() { Value = "PenaltyKicksMadePer90", Text = "Penalties Scored per 90" },
                    new SelectListItem() { Value = "PenaltyKicksAttempted", Text = "Penalties Attempted" },
                    new SelectListItem() { Value = "PenaltyKicksConversionRate", Text = "Penalty Conversion Rate" },
                    new SelectListItem() { Value = "PenaltyKicksAttemptedPer90", Text = "Penalties Attempted per 90" },
                    new SelectListItem() { Value = "XG", Text = "xG" },
                    new SelectListItem() { Value = "XGPer90", Text = "xG per 90" },
                    new SelectListItem() { Value = "NonPenaltyXG", Text = "Non-penalty xG" },
                    new SelectListItem() { Value = "NonPenaltyXGPer90", Text = "Non-penalty xG per 90" },
                    new SelectListItem() { Value = "NonPenaltyXGPerShot", Text = "Non-penalty xG per Shot" },
                    new SelectListItem() { Value = "GoalsMinusXG", Text = "Goals minus xG" },
                    new SelectListItem() { Value = "NonPenaltyGoalsMinusXG", Text = "Non-penalty Goals minus xG" },
                    new SelectListItem() { Value = "TouchesDefensivePenaltyArea", Text = "Touches in Defensive Penalty Area" },
                    new SelectListItem() { Value = "TouchesDefensivePenaltyAreaPer90", Text = "Touches in Defensive Penalty Area per 90" },
                    new SelectListItem() { Value = "TouchesDefensiveThird", Text = "Touches in Defensive Third" },
                    new SelectListItem() { Value = "TouchesDefensiveThirdPer90", Text = "Touches in Defensive Third per 90" },
                    new SelectListItem() { Value = "TouchesMiddleThird", Text = "Touches in Defensive Middle Third" },
                    new SelectListItem() { Value = "TouchesMiddleThirdPer90", Text = "Touches in Defensive Middle Third per 90" },
                    new SelectListItem() { Value = "TouchesAttackingThird", Text = "Touches in Defensive Attacking Third" },
                    new SelectListItem() { Value = "TouchesAttackingThirdPer90", Text = "Touches in Defensive Attacking Third per 90" },
                    new SelectListItem() { Value = "TouchesAttackingPenaltyArea", Text = "Touches in Defensive Attacking Penalty Area" },
                    new SelectListItem() { Value = "TouchesAttackingPenaltyAreaPer90", Text = "Touches in Defensive Attacking Penalty Area per 90" },
                    new SelectListItem() { Value = "Touches", Text = "Touches" },
                    new SelectListItem() { Value = "TouchesPer90", Text = "Touches per 90" },
                    new SelectListItem() { Value = "LiveBallTouches", Text = "Live Ball Touches" },
                    new SelectListItem() { Value = "LiveBallTouchesPer90", Text = "Live Ball Touches per 90" },
                    new SelectListItem() { Value = "DribblesAttempted", Text = "Dribbles Attempted" },
                    new SelectListItem() { Value = "DribblesAttemptedPer90", Text = "Dribbles Attempted per 90" },
                    new SelectListItem() { Value = "SuccessfulDribbles", Text = "Successful Dribbles" },
                    new SelectListItem() { Value = "SuccessfulDribblesPer90", Text = "Successful Dribbles per 90" },
                    new SelectListItem() { Value = "SuccessfulDribblesPercentage", Text = "Successful Dribbles %" },
                    new SelectListItem() { Value = "AverageSuccessfulDribblesPercentage", Text = "Average Successful Dribbles %" },
                    new SelectListItem() { Value = "PlayersDribbledPast", Text = "Players Dribbled Past" },
                    new SelectListItem() { Value = "PlayersDribbledPastPer90", Text = "Players Dribbled Past per 90" },
                    new SelectListItem() { Value = "Nutmegs", Text = "Nutmegs" },
                    new SelectListItem() { Value = "NutmegsPer90", Text = "Nutmegs per 90" },
                    new SelectListItem() { Value = "Carries", Text = "Carries" },
                    new SelectListItem() { Value = "CarriesPer90", Text = "Carries per 90" },
                    new SelectListItem() { Value = "YardsCarried", Text = "Yards Carried" },
                    new SelectListItem() { Value = "YardsCarriedPer90", Text = "Yards Carried per 90" },
                    new SelectListItem() { Value = "YardsProgressiveCarries", Text = "Yards Carried (Progressive)" },
                    new SelectListItem() { Value = "YardsProgressiveCarriesPer90", Text = "Yards Carried (Progressive) per 90" },
                    new SelectListItem() { Value = "YardsPerCarry", Text = "Yards per Carry" },
                    new SelectListItem() { Value = "WasTargetOfPass", Text = "Times Player was Target of Pass" },
                    new SelectListItem() { Value = "WasTargetOfPassPer90", Text = "Times Player was Target of Pass per 90" },
                    new SelectListItem() { Value = "PassesReceived", Text = "Passes Received by Player" },
                    new SelectListItem() { Value = "PassesReceivedPer90", Text = "Passes Receieved by Player per 90" },
                    new SelectListItem() { Value = "PassesReceivedPercentage", Text = "Passes Received %" },
                    new SelectListItem() { Value = "AveragePassesReceivedPercentage", Text = "Average Passes Received %" },
                    new SelectListItem() { Value = "Miscontrols", Text = "Miscontrols" },
                    new SelectListItem() { Value = "MiscontrolsPer90", Text = "Miscontrols per 90" },
                    new SelectListItem() { Value = "Dispossessed", Text = "Times Dispossessed" },
                    new SelectListItem() { Value = "DispossessedPer90", Text = "Times Dispossessed per 90" },
                    new SelectListItem() { Value = "PassesAttemptedLiveBall", Text = "Passes Attempted (Live Ball)" },
                    new SelectListItem() { Value = "PassesAttemptedLiveBallPer90", Text = "Passes Attempted (Live Ball) per 90" },
                    new SelectListItem() { Value = "PassesAttemptedDeadBall", Text = "Passes Attempted (Dead Ball) per 90" },
                    new SelectListItem() { Value = "PassesAttemptedDeadBallPer90", Text = "Passes Attempted (Dead Ball) per 90" },
                    new SelectListItem() { Value = "PassesAttemptedFreeKick", Text = "Passes Attempted (Free Kick)" },
                    new SelectListItem() { Value = "PassesAttemptedFreeKickPer90", Text = "Passes Attempted (Free Kick) per 90" },
                    new SelectListItem() { Value = "PassesCompletedThroughBall", Text = "Passes Completed (Through Ball)" },
                    new SelectListItem() { Value = "PassesCompletedThroughBallPer90", Text = "Passes Completed (Through Ball) per 90" },
                    new SelectListItem() { Value = "PassesCompletedUnderPressure", Text = "Passes Completed (Under Pressure)" },
                    new SelectListItem() { Value = "PassesCompletedUnderPressurePer90", Text = "Passes Completed (Under Pressure) per 90" },
                    new SelectListItem() { Value = "Switches", Text = "Switches" },
                    new SelectListItem() { Value = "SwitchesPer90", Text = "Switches per 90" },
                    new SelectListItem() { Value = "Crosses", Text = "Crosses" },
                    new SelectListItem() { Value = "CrossesPer90", Text = "Crosses per 90" },
                    new SelectListItem() { Value = "CornerKicks", Text = "Corner Kicks" },
                    new SelectListItem() { Value = "CornerKicksPer90", Text = "Corner Kicks per 90" },
                    new SelectListItem() { Value = "CornerKicksInswinging", Text = "Corner Kicks (Inswinging)" },
                    new SelectListItem() { Value = "CornerKicksInswingingPer90", Text = "Corner Kicks (Inswinging) per 90" },
                    new SelectListItem() { Value = "CornerKicksOutswinging", Text = "Corner Kicks (Outswinging)" },
                    new SelectListItem() { Value = "CornerKicksOutswingingPer90", Text = "Corner Kicks (Outswinging) per 90" },
                    new SelectListItem() { Value = "CornerKicksStraight", Text = "Corner Kicks (Straight)" },
                    new SelectListItem() { Value = "CornerKicksStraightPer90", Text = "Corner Kicks (Straight) per 90" },
                    new SelectListItem() { Value = "PassesGround", Text = "Ground Passes" },
                    new SelectListItem() { Value = "PassesGroundPer90", Text = "Ground Passes per 90" },
                    new SelectListItem() { Value = "PassesLow", Text = "Low Passes (Below Shoulder)" },
                    new SelectListItem() { Value = "PassesLowPer90", Text = "Low Passes per 90" },
                    new SelectListItem() { Value = "PassesHigh", Text = "High Passes (Above Shoulder)" },
                    new SelectListItem() { Value = "PassesHighPer90", Text = "High Passes per 90" },
                    new SelectListItem() { Value = "PassesLeftFoot", Text = "Left Foot Passes" },
                    new SelectListItem() { Value = "PassesLeftFootPer90", Text = "Passes Left Foot per 90" },
                    new SelectListItem() { Value = "PassesRightFoot", Text = "Right Foot Passes" },
                    new SelectListItem() { Value = "PassesRightFootPer90", Text = "Right Foot Passes per 90" },
                    new SelectListItem() { Value = "PassesHeaded", Text = "Headed Passes" },
                    new SelectListItem() { Value = "PassesHeadedPer90", Text = "Headed Passes per 90" },
                    new SelectListItem() { Value = "PassesThrowIn", Text = "Throw In Passes" },
                    new SelectListItem() { Value = "PassesThrowInPer90", Text = "Throw In Passes per 90" },
                    new SelectListItem() { Value = "PassesOther", Text = "Passes (Other)" },
                    new SelectListItem() { Value = "PassesOtherPer90", Text = "Passes (Other) per 90" },
                    new SelectListItem() { Value = "PassesOffside", Text = "Offside Passes" },
                    new SelectListItem() { Value = "PassesOffsidePer90", Text = "Offside Passes per 90" },
                    new SelectListItem() { Value = "PassesOutOfBounds", Text = "Out of Bounds Passes" },
                    new SelectListItem() { Value = "PassesOutOfBoundsPer90", Text = "Out of Bounds Passes per 90" },
                    new SelectListItem() { Value = "PassesAttemptedIntercepted", Text = "Passes Attempted (Intercepted)" },
                    new SelectListItem() { Value = "PassesAttemptedInterceptedPer90", Text = "Passes Attempted (Intercepted) per 90" },
                    new SelectListItem() { Value = "PassesAttemptedBlocked", Text = "Passes Attempted (Blocked)" },
                    new SelectListItem() { Value = "PassesAttemptedBlockedPer90", Text = "Passes Attempted (Blocked) per 90" },
                    new SelectListItem() { Value = "PassesCompleted", Text = "Passes Completed" },
                    new SelectListItem() { Value = "PassesCompletedPer90", Text = "Passes Completed per 90" },
                    new SelectListItem() { Value = "PassesAttempted", Text = "Passes Attempted" },
                    new SelectListItem() { Value = "PassesAttemptedPer90", Text = "Passes Attempted per 90" },
                    new SelectListItem() { Value = "AveragePassesCompletedPercentage", Text = "Average Passes Completed %" },
                    new SelectListItem() { Value = "PassesCompletedPercentage", Text = "Passes Completed %" },
                    new SelectListItem() { Value = "YardsPassed", Text = "Yards Passed" },
                    new SelectListItem() { Value = "YardsPassedPer90", Text = "Yards Passed per 90" },
                    new SelectListItem() { Value = "YardsPassedProgressive", Text = "Yards Passed Progressive" },
                    new SelectListItem() { Value = "YardsPassedProgressivePer90", Text = "Yards Passed Progressive per 90" },
                    new SelectListItem() { Value = "ShortPassesCompleted", Text = "Short Passes (5-15 yds) Completed" },
                    new SelectListItem() { Value = "ShortPassesCompletedPer90", Text = "Short Passes (5-15 yds) Completed per 90" },
                    new SelectListItem() { Value = "ShortPassesAttempted", Text = "Short Passes (5-15 yds) Attempted" },
                    new SelectListItem() { Value = "ShortPassesAttemptedPer90", Text = "Short Passes (5-15 yds) Attempted per 90" },
                    new SelectListItem() { Value = "AverageShortPassesCompletedPercentage", Text = "Average Short Passes (5-15 yds) Completed %" },
                    new SelectListItem() { Value = "ShortPassesCompletedPercentage", Text = "Short Passes (5-15 yds) Completed %" },
                    new SelectListItem() { Value = "MediumPassesCompleted", Text = "Medium Passes (15-30 yds) Completed" },
                    new SelectListItem() { Value = "MediumPassesCompletedPer90", Text = "Medium Passes (15-30 yds) Completed per 90" },
                    new SelectListItem() { Value = "MediumPassesAttempted", Text = "Medium Passes (15-30 yds) Attempted" },
                    new SelectListItem() { Value = "MediumPassesAttemptedPer90", Text = "Medium Passes (15-30 yds) Attempted per 90" },
                    new SelectListItem() { Value = "AverageMediumPassesCompletedPercentage", Text = "Average Medium Passes (15-30 yds) Completed %" },
                    new SelectListItem() { Value = "MediumPassesCompletedPercentage", Text = "Medium Passes (15-30 yds) Completed %" },
                    new SelectListItem() { Value = "LongPassesCompleted", Text = "Long Passes (30+ yds) Completed" },
                    new SelectListItem() { Value = "LongPassesCompletedPer90", Text = "Long Passes (30+ yds) Completed per 90" },
                    new SelectListItem() { Value = "LongPassesAttempted", Text = "Long Passes (30+ yds) Attempted" },
                    new SelectListItem() { Value = "LongPassesAttemptedPer90", Text = "Long Passes (30+ yds) Attempted per 90" },
                    new SelectListItem() { Value = "AverageLongPassesCompletedPercentage", Text = "Average Long Passes (30+ yds) Completed %" },
                    new SelectListItem() { Value = "LongPassesCompletedPercentage", Text = "Long Passes (30+ yds) Completed %" },
                    new SelectListItem() { Value = "Assists", Text = "Assists" },
                    new SelectListItem() { Value = "AssistsPer90", Text = "Assists per 90" },
                    new SelectListItem() { Value = "XGAssisted", Text = "xA" },
                    new SelectListItem() { Value = "XGAssistedPer90", Text = "xA per 90" },
                    new SelectListItem() { Value = "KeyPasses", Text = "Key Passes" },
                    new SelectListItem() { Value = "KeyPassesPer90", Text = "Key Passes per 90" },
                    new SelectListItem() { Value = "ChancesCreated", Text = "Chances Created" },
                    new SelectListItem() { Value = "ChancesCreatedPer90", Text = "Chances Created per 90" },
                    new SelectListItem() { Value = "PassesIntoFinalThird", Text = "Passes Into Final Third" },
                    new SelectListItem() { Value = "PassesIntoFinalThirdPer90", Text = "Passes Into Final Third per 90" },
                    new SelectListItem() { Value = "PassesIntoPenaltyArea", Text = "Passes Into Penalty Area" },
                    new SelectListItem() { Value = "PassesIntoPenaltyAreaPer90", Text = "Passes Into Penalty Area per 90" },
                    new SelectListItem() { Value = "CrossesIntoPenaltyArea", Text = "Cross Into Penalty Area" },
                    new SelectListItem() { Value = "CrossesIntoPenaltyAreaPer90", Text = "Crosses Into Penalty Area per 90" },
                    new SelectListItem() { Value = "ProgressivePasses", Text = "Progressive Passes per 90" },
                    new SelectListItem() { Value = "ProgressivePassesPer90", Text = "Progressive Passes per 90" },
                    new SelectListItem() { Value = "AverageProgressivePassesPercentage", Text = "Average Progressive Passes %" },
                    new SelectListItem() { Value = "ProgressivePassesPercentage", Text = "Progressive Passes %" },
                    new SelectListItem() { Value = "YellowCards", Text = "Yellow Cards" },
                    new SelectListItem() { Value = "RedCards", Text = "Red Cards" },
                    new SelectListItem() { Value = "Fouls", Text = "Fouls" },
                    new SelectListItem() { Value = "FoulsPer90", Text = "Fouls per 90" },
                    new SelectListItem() { Value = "FoulsDrawn", Text = "Fouls Drawn" },
                    new SelectListItem() { Value = "FoulsDrawnPer90", Text = "Fouls Drawn per 90" },
                    new SelectListItem() { Value = "Offsides", Text = "Offsides" },
                    new SelectListItem() { Value = "OffsidesPer90", Text = "Offsides per 90" },
                    new SelectListItem() { Value = "PenaltyKicksConceded", Text = "Penalty Kicks Conceded" },
                    new SelectListItem() { Value = "PenaltyKicksConcededPer90", Text = "Penalty Kicks Conceded per 90" },
                    new SelectListItem() { Value = "OwnGoals", Text = "Own Goals" },
                    new SelectListItem() { Value = "OwnGoalsPer90", Text = "Own Goals per 90" },
                    new SelectListItem() { Value = "LooseBallsRecovered", Text = "Loose Balls Recovered" },
                    new SelectListItem() { Value = "LooseBallsRecoveredPer90", Text = "Loose Balls Recovered per 90" },
                    new SelectListItem() { Value = "AerialDualsWon", Text = "Aerial Duals Won" },
                    new SelectListItem() { Value = "AerialDualsWonPer90", Text = "Aerial Duals Won per 90" },
                    new SelectListItem() { Value = "AerialDualsLost", Text = "Aerial Duals Lost" },
                    new SelectListItem() { Value = "AerialDualsLostPer90", Text = "Aerial Duals Won per 90" },
                    new SelectListItem() { Value = "AverageAerialDualsWonPercentage", Text = "Average Aerial Duals Won %" },
                    new SelectListItem() { Value = "AerialDualsWonPercentage", Text = "Aerial Duals Won %" },
                    new SelectListItem() { Value = "GkShotsOnTargetFacedPer90", Text = "Shots on Target Faced" },
                    new SelectListItem() { Value = "GkGoalsConceded", Text = "Goals Conceded" },
                    new SelectListItem() { Value = "GkGoalsConcededPer90", Text = "Goals Conceded per 90" },
                    new SelectListItem() { Value = "GkSaves", Text = "Saves" },
                    new SelectListItem() { Value = "GkSavesPer90", Text = "Saves per 90" },
                    new SelectListItem() { Value = "GkAverageSavesPercentage", Text = "Average Saves %" },
                    new SelectListItem() { Value = "GkSavesPercentage", Text = "Saves %" },
                    new SelectListItem() { Value = "GkCleanSheets", Text = "Clean Sheets" },
                    new SelectListItem() { Value = "GkPostShotXG", Text = "Post Shot xG" },
                    new SelectListItem() { Value = "GkPostShotXGPer90", Text = "Post Shot cG per 90" },
                    new SelectListItem() { Value = "GkPassesCompletedOver40Yards", Text = "Passes Completed >40 yds" },
                    new SelectListItem() { Value = "GkPassesCompletedOver40YardsPer90", Text = "Passes Completed >40 yds per 90" },
                    new SelectListItem() { Value = "GkPassesAttemptedOver40Yards", Text = "Passes Attempted >40 yds" },
                    new SelectListItem() { Value = "GkPassesAttemptedOver40YardsPer90", Text = "Passes Attempted >40 yds per 90" },
                    new SelectListItem() { Value = "GkAveragePassesCompletedOver40YardsPercentage", Text = "Average Passes Completed >40 yds %" },
                    new SelectListItem() { Value = "GkPassesCompletedOver40YardsPercentage", Text = "Passes Completed >40 yds %" },
                    new SelectListItem() { Value = "GkThrowsAttempted", Text = "Throws Attempted" },
                    new SelectListItem() { Value = "GkThrowsAttemptedPer90", Text = "Throws Attempted per 90" },
                    new SelectListItem() { Value = "GkAveragePassesAttemptedOver40YardsPercentage", Text = "Average Passes Attempted >40 yds %" },
                    new SelectListItem() { Value = "GkPassesAttemptedOver40YardsPercentage", Text = "Passes Attempted >40 yds %" },
                    new SelectListItem() { Value = "GkAverageYardsPassLength", Text = "Average Pass Length (yds)" },
                    new SelectListItem() { Value = "GkGoalKicksAttempted", Text = "Goal Kicks Attempted" },
                    new SelectListItem() { Value = "GkGoalKicksAttemptedPer90", Text = "Goal Kicks Attempted per 90" },
                    new SelectListItem() { Value = "GkAverageGoalKicksLaunchedPercentage", Text = "Avg Goal Kicks Launched %" },
                    new SelectListItem() { Value = "GkGoalKickAverageYards", Text = "Goal Kicks Avg yds" },
                    new SelectListItem() { Value = "GkOpponentCrossesAttempted", Text = "Opponent Crosses Attempted" },
                    new SelectListItem() { Value = "GkAverageCrossesStoppedPercentage", Text = "Avg Crosses Stopped %" },
                    new SelectListItem() { Value = "GkOpponentCrossesStoppedPercentage", Text = "Opponent Crosses Stopped %" },
                    new SelectListItem() { Value = "GkDefensiveActionsOutsidePenaltyArea", Text = "Defensive Actions Outside Box" },
                    new SelectListItem() { Value = "GkDefensiveActionsOutsidePenaltyAreaPer90", Text = "Defensive Actions Outside Box per 90" },
                    new SelectListItem() { Value = "GkAverageDistanceFromGoalForDefensiveActions", Text = "Avg Distance From Goal for Defensive Action" },
                    new SelectListItem() { Value = "ShotCreatingActions", Text = "Shot Creating Actions" },
                    new SelectListItem() { Value = "ShotCreatingActionsPer90", Text = "Shot Creating Actions per 90" },
                    new SelectListItem() { Value = "PassesCompletedLiveBallLeadingToShot", Text = "Passes Completed (Live Ball) Leading to Shot" },
                    new SelectListItem() { Value = "PassesCompletedLiveBallLeadingToShotPer90", Text = "Passes Completed (Live Ball) Leading to Shot per 90" },
                    new SelectListItem() { Value = "PassesCompletedDeadBallLeadingToShot", Text = "Passes Completed (Dead Ball) Leading to Shot" },
                    new SelectListItem() { Value = "PassesCompletedDeadBallLeadingToShotPer90", Text = "Passes Completed (Dead Ball) Leading to Shot per 90" },
                    new SelectListItem() { Value = "DribblesLeadingToShot", Text = "Dribbles Leading to Shot" },
                    new SelectListItem() { Value = "DribblesLeadingToShotPer90", Text = "Dribbles Leading to Shot per 90" },
                    new SelectListItem() { Value = "ShotsLeadingToAnotherShot", Text = "Shots Leading to Another Shot" },
                    new SelectListItem() { Value = "ShotsLeadingToAnotherShotPer90", Text = "Shots Leading to Another Shot per 90" },
                    new SelectListItem() { Value = "FoulsDrawnLeadingToShot", Text = "Fouls Drawn Leading to Shot" },
                    new SelectListItem() { Value = "FoulsDrawnLeadingToShotPer90", Text = "Fouls Drawn Leading to Shot per 90" },
                    new SelectListItem() { Value = "PassesCompletedLiveBallLeadingToGoal", Text = "Passes Completed (Live Ball) Leading to Goal" },
                    new SelectListItem() { Value = "PassesCompletedLiveBallLeadingToGoalPer90", Text = "Passes Completed (Live Ball) Leading to Goal per 90" },
                    new SelectListItem() { Value = "PassesCompletedDeadBallLeadingToGoal", Text = "Passes Completed (Dead Ball) Leading to Goal" },
                    new SelectListItem() { Value = "PassesCompletedDeadBallLeadingToGoalPer90", Text = "Passes Completed (Dead Ball) Leading to Goal per 90" },
                    new SelectListItem() { Value = "DribblesLeadingToGoal", Text = "Dribbles Leading to Goal" },
                    new SelectListItem() { Value = "DribblesLeadingToGoalPer90", Text = "Dribbles Leading to Goal per 90" },
                    new SelectListItem() { Value = "ShotsLeadingToAnotherGoal", Text = "Shots Leading to Another Shot" },
                    new SelectListItem() { Value = "ShotsLeadingToAnotherGoalPer90", Text = "Shots Leading to Another Goal per 90" },
                    new SelectListItem() { Value = "FoulsDrawnLeadingToGoal", Text = "Fouls Drawn Leading to Goal" },
                    new SelectListItem() { Value = "FoulsDrawnLeadingToGoalPer90", Text = "Fouls Drawn Leading to Goal per 90" },
                    new SelectListItem() { Value = "ActionsLeadingToOpponentOwnGoal", Text = "Actions Leading to Opponent Own Goal" },
                    new SelectListItem() { Value = "ActionsLeadingToOpponentOwnGoalPer90", Text = "Actions Leading to Opponent Own Goal per 90" },
                    new SelectListItem() { Value = "PlayersTackled", Text = "Players Tackled" },
                    new SelectListItem() { Value = "PlayersTackledPer90", Text = "Players Tackled per 90" },
                    new SelectListItem() { Value = "TacklesWon", Text = "Tackles Won" },
                    new SelectListItem() { Value = "TacklesWonPer90", Text = "Tackles Won per 90" },
                    new SelectListItem() { Value = "TacklesDefensiveThird", Text = "Tackles Defensive Third" },
                    new SelectListItem() { Value = "TacklesMiddleThird", Text = "Tackles Middle Third" },
                    new SelectListItem() { Value = "TacklesAttackingThird", Text = "Tackles Attacking Third" },
                    new SelectListItem() { Value = "DribblersTackled", Text = "Dribblers Tackled" },
                    new SelectListItem() { Value = "DribblesContested", Text = "Dribbles Contested" },
                    new SelectListItem() { Value = "AverageDribblersTackledPercentage", Text = "Avg Dribblers Tackled %" },
                    new SelectListItem() { Value = "DribblersTackledPercentage", Text = "Dribblers Tackled %" },
                    new SelectListItem() { Value = "TimesDribbledPast", Text = "Times Dribbled Past" },
                    new SelectListItem() { Value = "TimesDribbledPastPer90", Text = "Time Dribbled Past per 90" },
                    new SelectListItem() { Value = "Pressures", Text = "Pressures" },
                    new SelectListItem() { Value = "PressuresPer90", Text = "Pressures per 90" },
                    new SelectListItem() { Value = "SuccessfulPressures", Text = "Successful Pressures" },
                    new SelectListItem() { Value = "SuccessfulPressuresPer90", Text = "Successful Pressures per 90" },
                    new SelectListItem() { Value = "AverageSuccessfulPressuresPercentage", Text = "Avg Successful Pressures %" },
                    new SelectListItem() { Value = "SuccessfulPressuresPercentage", Text = "Successful Pressures %" },
                    new SelectListItem() { Value = "PressuresDefensiveThird", Text = "Pressures Defensive Third" },
                    new SelectListItem() { Value = "PressuresMiddleThird", Text = "Pressures Middle Third" },
                    new SelectListItem() { Value = "PressuresAttackingThird", Text = "Pressures Attacking Third" },
                    new SelectListItem() { Value = "Blocks", Text = "Blocks" },
                    new SelectListItem() { Value = "BlocksPer90", Text = "Blocks per 90" },
                    new SelectListItem() { Value = "ShotsBlocked", Text = "Shots Blocked" },
                    new SelectListItem() { Value = "ShotsOnTargetBlocked", Text = "Shots on Target Blocked" },
                    new SelectListItem() { Value = "PassesBlocked", Text = "Passes Blocked" },
                    new SelectListItem() { Value = "Interceptions", Text = "Interceptions" },
                    new SelectListItem() { Value = "InterceptionsPer90", Text = "Interceptions per 90" },
                    new SelectListItem() { Value = "PlayersTackledAndInterceptions", Text = "Players Tackled + Interceptions" },
                    new SelectListItem() { Value = "PlayersTackledAndInterceptionsPer90", Text = "Players Tackled + Interceptions per 90" },
                    new SelectListItem() { Value = "Clearances", Text = "Clearances" },
                    new SelectListItem() { Value = "ClearancesPer90", Text = "Clearances per 90" },
                    new SelectListItem() { Value = "ErrorsLeadingToShot", Text = "Errors Leading to Shot" },
                    new SelectListItem() { Value = "ErrorsLeadingToShotPer90", Text = "Errors Leading to Shot per 90" }
                };
            }
        }
    }
}
