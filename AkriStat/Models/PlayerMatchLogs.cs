﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class PlayerMatchLogs
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public bool Started { get; set; }
        public string PositionPlayed { get; set; }
        public int MinutesPlayed { get; set; }
        public int? Goals { get; set; }
        public int? Shots { get; set; }
        public int? ShotsOnTarget { get; set; }
        public decimal? ShotsOnTargetPercentage { get; set; }
        public decimal? GoalsPerShot { get; set; }
        public decimal? GoalsPerShotOnTarget { get; set; }
        public int? PenaltyKicksMade { get; set; }
        public int? PenaltyKicksAttempted { get; set; }
        public decimal? XG { get; set; }
        public decimal? NonPenaltyXG { get; set; }
        public decimal? NonPenaltyXgPerShot { get; set; }
        public decimal? GoalsMinusXG { get; set; }
        public decimal? NonPenaltyGoalsMinusXG { get; set; }
        public int? ShotCreatingActions { get; set; }
        public int? PassesCompletedLiveBallLeadingToShot { get; set; }
        public int? PassesCompletedDeadBallLeadingToShot { get; set; }
        public int? DribblesLeadingToShot { get; set; }
        public int? ShotsLeadingToAnotherShot { get; set; }
        public int? FoulsDrawnLeadingToShot { get; set; }
        public int? GoalCreatingActions { get; set; }
        public int? PassesCompletedLiveBallLeadingToGoal { get; set; }
        public int? PassesCompletedDeadBallLeadingToGoal { get; set; }
        public int? DribblesLeadingToGoal { get; set; }
        public int? ShotsLeadingToAnotherGoal { get; set; }
        public int? FoulsDrawnLeadingToGoal { get; set; }
        public int? ActionsLeadingToOpponentOwnGoal { get; set; }
        public int? PassesCompleted { get; set; }
        public int? PassesAttempted { get; set; }
        public decimal? PassesCompletedPercentage { get; set; }
        public int? YardsPassed { get; set; }
        public int? YardsPassedProgressive { get; set; }
        public int? ShortPassesCompleted { get; set; }
        public int? ShortPassesAttempted { get; set; }
        public decimal? ShortPassesCompletedPercentage { get; set; }
        public int? MediumPassesCompleted { get; set; }
        public int? MediumPassesAttempted { get; set; }
        public decimal? MediumPassesCompletedPercentage { get; set; }
        public int? LongPassesCompleted { get; set; }
        public int? LongPassesAttempted { get; set; }
        public decimal? LongPassesCompletedPercentage { get; set; }
        public int? Assists { get; set; }
        public decimal? XGAssisted { get; set; }
        public int? KeyPasses { get; set; }
        public int? ChancesCreated { get; set; }
        public int? PassesIntoFinalThird { get; set; }
        public int? PassesIntoPenaltyArea { get; set; }
        public int? CrossesIntoPenaltyArea { get; set; }
        public int? ProgressivePasses { get; set; }
        public decimal? ProgressivePassesPercentage { get; set; }
        public int? PassesAttemptedLiveBall { get; set; }
        public int? PassesAttemptedDeadBall { get; set; }
        public int? PassesAttemptedFreeKick { get; set; }
        public int? PassesCompletedThroughBall { get; set; }
        public int? PassesCompletedUnderPressure { get; set; }
        public int? Switches { get; set; }
        public int? Crosses { get; set; }
        public int? CornerKicks { get; set; }
        public int? CornerKicksInswinging { get; set; }
        public int? CornerKicksOutswinging { get; set; }
        public int? CornerKicksStraight { get; set; }
        public int? PassesGround { get; set; }
        public int? PassesLow { get; set; }
        public int? PassesHigh { get; set; }
        public int? PassesLeftFoot { get; set; }
        public int? PassesRightFoot { get; set; }
        public int? PassesHeaded { get; set; }
        public int? PassesThrowIn { get; set; }
        public int? PassesOther { get; set; }
        public int? PassesOffside { get; set; }
        public int? PassesOutOfBounds { get; set; }
        public int? PassesAttemptedIntercepted { get; set; }
        public int? PassesAttemptedBlocked { get; set; }
        public int? TouchesDefensivePenaltyArea { get; set; }
        public int? TouchesDefensiveThird { get; set; }
        public int? TouchesMiddleThird { get; set; }
        public int? TouchesAttackingThird { get; set; }
        public int? TouchesAttackingPenaltyArea { get; set; }
        public int? Touches { get; set; }
        public int? LiveBallTouches { get; set; }
        public int? DribblesAttempted { get; set; }
        public int? SuccessfulDribbles { get; set; }
        public decimal? SuccessfulDribblesPercentage { get; set; }
        public int? PlayersDribbledPast { get; set; }
        public int? Nutmegs { get; set; }
        public int? ControlledBallWithFeet { get; set; }
        public int? YardsControlledWithFeet { get; set; }
        public int? YardsProgressiveControlledWithFeet { get; set; }
        public int? WasTargetOfPass { get; set; }
        public int? PassesReceived { get; set; }
        public decimal? PassesReceivedPercentage { get; set; }
        public int? Miscontrols { get; set; }
        public int? Dispossessed { get; set; }
        public int? PlayersTackled { get; set; }
        public int? TacklesWon { get; set; }
        public int? TacklesDefensiveThird { get; set; }
        public int? TacklesMiddleThird { get; set; }
        public int? TacklesAttackingThird { get; set; }
        public int? DribblersTackled { get; set; }
        public int? TimesDribbledPast { get; set; }
        public int? DribblesContested { get; set; }
        public decimal? DribblersTackledPercentage { get; set; }
        public int? PressuresDefensiveThird { get; set; }
        public int? PressuresMiddleThird { get; set; }
        public int? PressuresAttackingThird { get; set; }
        public int? Pressures { get; set; }
        public int? SuccessfulPressures { get; set; }
        public decimal? SuccessfulPressuresPercentage { get; set; }
        public int? ShotsBlocked { get; set; }
        public int? ShotsOnTargetBlocked { get; set; }
        public int? PassesBlocked { get; set; }
        public int? Blocks { get; set; }
        public int? PlayersTackledAndInterceptions { get; set; }
        public int? Interceptions { get; set; }
        public int? Clearances { get; set; }
        public int? ErrorsLeadingToShot { get; set; }
        public bool? YellowCard { get; set; }
        public bool? RedCard { get; set; }
        public bool? TwoYellowCards { get; set; }
        public int? Fouls { get; set; }
        public int? FoulsDrawn { get; set; }
        public int? Offsides { get; set; }
        public int? PenaltyKicksWon { get; set; }
        public int? PenaltyKicksConceded { get; set; }
        public int? OwnGoals { get; set; }
        public int? LooseBallsRecovered { get; set; }
        public int? AerialDualsWon { get; set; }
        public int? AerialDualsLost { get; set; }
        public decimal? AerialDualsWonPercentage { get; set; }
        public int? GkShotsOnTargetFaced { get; set; }
        public int? GkGoalsConceded { get; set; }
        public int? GkSaves { get; set; }
        public decimal? GkSavesPercentage { get; set; }
        public bool? GkCleanSheet { get; set; }
        public decimal? GkPostShotXG { get; set; }
        public int? GkPenaltiesFaced { get; set; }
        public int? GkPenaltiesConceded { get; set; }
        public int? GkPenaltiesSaved { get; set; }
        public int? GkPenaltiesFacedMissed { get; set; }
        public int? GkPassesCompletedOver40Yards { get; set; }
        public int? GkPassesAttemptedOver40Yards { get; set; }
        public decimal? GkPassesCompletedOver40YardsPercentage { get; set; }
        public int? GkPassesAttempted { get; set; }
        public int? GkThrowsAttempted { get; set; }
        public decimal? GkPassesOver40YardsPercentage { get; set; }
        public decimal? GkAverageYardsPassLength { get; set; }
        public int? GkGoalKicksAttempted { get; set; }
        public decimal? GkGoalKicksLaunchedPercentage { get; set; }
        public decimal? GkGoalKickAverageYards { get; set; }
        public int? GkOpponentCrossesAttempted { get; set; }
        public int? GkCrossesStopped { get; set; }
        public decimal? GkCrossesStoppedPercentage { get; set; }
        public int? GkDefensiveActionsOutsidePenaltyArea { get; set; }
        public decimal? GkAverageDistanceFromGoalForDefensiveActions { get; set; }

        public virtual Matches Match { get; set; }
        public virtual Players Player { get; set; }
        public virtual Teams Team { get; set; }
    }
}
