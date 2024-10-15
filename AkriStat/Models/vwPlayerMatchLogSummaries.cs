﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class vwPlayerMatchLogSummaries
    {
        public int PlayerID { get; set; }
        public string Position { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        public int? GamesPlayed { get; set; }
        public int? MinutesPlayed { get; set; }
        public int? Goals { get; set; }
        public double GoalsPer90 { get; set; }
        public int? Shots { get; set; }
        public double ShotsPer90 { get; set; }
        public int? ShotsOnTarget { get; set; }
        public double ShotsOnTargetPer90 { get; set; }
        public double ShotsOnTargetPercentage { get; set; }
        public decimal AverageShotsOnTargetPercentage { get; set; }
        public double ShotsPerTouch { get; set; }
        public double GoalsPerShot { get; set; }
        public int? PenaltyKicksMade { get; set; }
        public double PenaltyKicksMadePer90 { get; set; }
        public int? PenaltyKicksAttempted { get; set; }
        public double PenaltyKicksConversionRate { get; set; }
        public double PenaltyKicksAttemptedPer90 { get; set; }
        public decimal? XG { get; set; }
        public double XGPer90 { get; set; }
        public decimal? NonPenaltyXG { get; set; }
        public double NonPenaltyXGPer90 { get; set; }
        public double NonPenaltyXGPerShot { get; set; }
        public decimal? GoalsMinusXG { get; set; }
        public decimal? NonPenaltyGoalsMinusXG { get; set; }
        public int? TouchesDefensivePenaltyArea { get; set; }
        public double TouchesDefensivePenaltyAreaPer90 { get; set; }
        public int? TouchesDefensiveThird { get; set; }
        public double TouchesDefensiveThirdPer90 { get; set; }
        public int? TouchesMiddleThird { get; set; }
        public double TouchesMiddleThirdPer90 { get; set; }
        public int? TouchesAttackingThird { get; set; }
        public double TouchesAttackingThirdPer90 { get; set; }
        public int? TouchesAttackingPenaltyArea { get; set; }
        public double TouchesAttackingPenaltyAreaPer90 { get; set; }
        public int? Touches { get; set; }
        public double TouchesPer90 { get; set; }
        public int? LiveBallTouches { get; set; }
        public double LiveBallTouchesPer90 { get; set; }
        public int? DribblesAttempted { get; set; }
        public double DribblesAttemptedPer90 { get; set; }
        public int? SuccessfulDribbles { get; set; }
        public double SuccessfulDribblesPer90 { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public decimal? AverageSuccessfulDribblesPercentage { get; set; }
        public int? PlayersDribbledPast { get; set; }
        public double PlayersDribbledPastPer90 { get; set; }
        public int? Nutmegs { get; set; }
        public double NutmegsPer90 { get; set; }
        public int? Carries { get; set; }
        public double CarriesPer90 { get; set; }
        public int? YardsCarried { get; set; }
        public double YardsCarriedPer90 { get; set; }
        public int? YardsProgressiveCarries { get; set; }
        public double YardsProgressiveCarriesPer90 { get; set; }
        public double? YardsPerCarry { get; set; }
        public int? WasTargetOfPass { get; set; }
        public double WasTargetOfPassPer90 { get; set; }
        public int? PassesReceived { get; set; }
        public double PassesReceivedPer90 { get; set; }
        public double PassesReceivedPercentage { get; set; }
        public decimal? AveragePassesReceivedPercentage { get; set; }
        public int? Miscontrols { get; set; }
        public double MiscontrolsPer90 { get; set; }
        public int? Dispossessed { get; set; }
        public double DispossessedPer90 { get; set; }
        public int? PassesAttemptedLiveBall { get; set; }
        public double PassesAttemptedLiveBallPer90 { get; set; }
        public int? PassesAttemptedDeadBall { get; set; }
        public double PassesAttemptedDeadBallPer90 { get; set; }
        public int? PassesAttemptedFreeKick { get; set; }
        public double PassesAttemptedFreeKickPer90 { get; set; }
        public int? PassesCompletedThroughBall { get; set; }
        public double PassesCompletedThroughBallPer90 { get; set; }
        public int? PassesCompletedUnderPressure { get; set; }
        public double PassesCompletedUnderPressurePer90 { get; set; }
        public int? Switches { get; set; }
        public double SwitchesPer90 { get; set; }
        public int? Crosses { get; set; }
        public double CrossesPer90 { get; set; }
        public int? CornerKicks { get; set; }
        public double CornerKicksPer90 { get; set; }
        public int? CornerKicksInswinging { get; set; }
        public double CornerKicksInswingingPer90 { get; set; }
        public int? CornerKicksOutswinging { get; set; }
        public double CornerKicksOutswingingPer90 { get; set; }
        public int? CornerKicksStraight { get; set; }
        public double CornerKicksStraightPer90 { get; set; }
        public int? PassesGround { get; set; }
        public double PassesGroundPer90 { get; set; }
        public int? PassesLow { get; set; }
        public double PassesLowPer90 { get; set; }
        public int? PassesHigh { get; set; }
        public double PassesHighPer90 { get; set; }
        public int? PassesLeftFoot { get; set; }
        public double PassesLeftFootPer90 { get; set; }
        public int? PassesRightFoot { get; set; }
        public double PassesRightFootPer90 { get; set; }
        public int? PassesHeaded { get; set; }
        public double PassesHeadedPer90 { get; set; }
        public int? PassesThrowIn { get; set; }
        public double PassesThrowInPer90 { get; set; }
        public int? PassesOther { get; set; }
        public double PassesOtherPer90 { get; set; }
        public int? PassesOffside { get; set; }
        public double PassesOffsidePer90 { get; set; }
        public int? PassesOutOfBounds { get; set; }
        public double PassesOutOfBoundsPer90 { get; set; }
        public int? PassesAttemptedIntercepted { get; set; }
        public double PassesAttemptedInterceptedPer90 { get; set; }
        public int? PassesAttemptedBlocked { get; set; }
        public double PassesAttemptedBlockedPer90 { get; set; }
        public int? PassesCompleted { get; set; }
        public double PassesCompletedPer90 { get; set; }
        public int? PassesAttempted { get; set; }
        public double PassesAttemptedPer90 { get; set; }
        public decimal? AveragePassesCompletedPercentage { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public int? YardsPassed { get; set; }
        public double YardsPassedPer90 { get; set; }
        public int? YardsPassedProgressive { get; set; }
        public double YardsPassedProgressivePer90 { get; set; }
        public int? ShortPassesCompleted { get; set; }
        public double ShortPassesCompletedPer90 { get; set; }
        public int? ShortPassesAttempted { get; set; }
        public double ShortPassesAttemptedPer90 { get; set; }
        public decimal? AverageShortPassesCompletedPercentage { get; set; }
        public double ShortPassesCompletedPercentage { get; set; }
        public int? MediumPassesCompleted { get; set; }
        public double MediumPassesCompletedPer90 { get; set; }
        public int? MediumPassesAttempted { get; set; }
        public double MediumPassesAttemptedPer90 { get; set; }
        public decimal? AverageMediumPassesCompletedPercentage { get; set; }
        public double MediumPassesCompletedPercentage { get; set; }
        public int? LongPassesCompleted { get; set; }
        public double LongPassesCompletedPer90 { get; set; }
        public int? LongPassesAttempted { get; set; }
        public double LongPassesAttemptedPer90 { get; set; }
        public decimal? AverageLongPassesCompletedPercentage { get; set; }
        public double LongPassesCompletedPercentage { get; set; }
        public int? Assists { get; set; }
        public double AssistsPer90 { get; set; }
        public decimal? XGAssisted { get; set; }
        public double XGAssistedPer90 { get; set; }
        public int? KeyPasses { get; set; }
        public double KeyPassesPer90 { get; set; }
        public int? ChancesCreated { get; set; }
        public double ChancesCreatedPer90 { get; set; }
        public int? PassesIntoFinalThird { get; set; }
        public double PassesIntoFinalThirdPer90 { get; set; }
        public int? PassesIntoPenaltyArea { get; set; }
        public double PassesIntoPenaltyAreaPer90 { get; set; }
        public int? CrossesIntoPenaltyArea { get; set; }
        public double CrossesIntoPenaltyAreaPer90 { get; set; }
        public int? ProgressivePasses { get; set; }
        public double ProgressivePassesPer90 { get; set; }
        public decimal? AverageProgressivePassesPercentage { get; set; }
        public double ProgressivePassesPercentage { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public int? Fouls { get; set; }
        public double FoulsPer90 { get; set; }
        public int? FoulsDrawn { get; set; }
        public double FoulsDrawnPer90 { get; set; }
        public int? Offsides { get; set; }
        public double OffsidesPer90 { get; set; }
        public int? PenaltyKicksConceded { get; set; }
        public double PenaltyKicksConcededPer90 { get; set; }
        public int? OwnGoals { get; set; }
        public double OwnGoalsPer90 { get; set; }
        public int? LooseBallsRecovered { get; set; }
        public double LooseBallsRecoveredPer90 { get; set; }
        public int? AerialDualsWon { get; set; }
        public double AerialDualsWonPer90 { get; set; }
        public int? AerialDualsLost { get; set; }
        public double AerialDualsLostPer90 { get; set; }
        public decimal? AverageAerialDualsWonPercentage { get; set; }
        public double AerialDualsWonPercentage { get; set; }
        public int? GkShotsOnTargetFaced { get; set; }
        public double GkShotsOnTargetFacedPer90 { get; set; }
        public int? GkGoalsConceded { get; set; }
        public double GkGoalsConcededPer90 { get; set; }
        public int? GkSaves { get; set; }
        public double GkSavesPer90 { get; set; }
        public decimal? GkAverageSavesPercentage { get; set; }
        public double GkSavesPercentage { get; set; }
        public int? GkCleanSheets { get; set; }
        public decimal? GkPostShotXG { get; set; }
        public double GkPostShotXGPer90 { get; set; }
        public double GkPostShotXGPerShotOnTargetFaced { get; set; }
        public int? GkPenaltiesFaced { get; set; }
        public double GkPenaltiesFacedPer90 { get; set; }
        public int? GkPenaltiesConceded { get; set; }
        public double GkPenaltiesConcededPer90 { get; set; }
        public int? GkPenaltiesSaved { get; set; }
        public double GkPenaltiesSavedPer90 { get; set; }
        public int? GkPenaltiesFacedMissed { get; set; }
        public double GkPenaltiesFacedMissedPer90 { get; set; }
        public int? GkPassesCompletedOver40Yards { get; set; }
        public double GkPassesCompletedOver40YardsPer90 { get; set; }
        public int? GkPassesAttemptedOver40Yards { get; set; }
        public double GkPassesAttemptedOver40YardsPer90 { get; set; }
        public decimal? GkAveragePassesCompletedOver40YardsPercentage { get; set; }
        public double GkPassesCompletedOver40YardsPercentage { get; set; }
        public int? GkThrowsAttempted { get; set; }
        public double GkThrowsAttemptedPer90 { get; set; }
        public decimal? GkAveragePassesAttemptedOver40YardsPercentage { get; set; }
        public double GkPassesAttemptedOver40YardsPercentage { get; set; }
        public decimal? GkAverageYardsPassLength { get; set; }
        public int? GkGoalKicksAttempted { get; set; }
        public double GkGoalKicksAttemptedPer90 { get; set; }
        public decimal? GkAverageGoalKicksLaunchedPercentage { get; set; }
        public decimal? GkGoalKickAverageYards { get; set; }
        public int? GkOpponentCrossesAttempted { get; set; }
        public int? GkCrossesStopped { get; set; }
        public decimal? GkAverageCrossesStoppedPercentage { get; set; }
        public double GkOpponentCrossesStoppedPercentage { get; set; }
        public int? GkDefensiveActionsOutsidePenaltyArea { get; set; }
        public double GkDefensiveActionsOutsidePenaltyAreaPer90 { get; set; }
        public decimal? GkAverageDistanceFromGoalForDefensiveActions { get; set; }
        public int? ShotCreatingActions { get; set; }
        public double ShotCreatingActionsPer90 { get; set; }
        public int? PassesCompletedLiveBallLeadingToShot { get; set; }
        public double PassesCompletedLiveBallLeadingToShotPer90 { get; set; }
        public int? PassesCompletedDeadBallLeadingToShot { get; set; }
        public double PassesCompletedDeadBallLeadingToShotPer90 { get; set; }
        public int? DribblesLeadingToShot { get; set; }
        public double DribblesLeadingToShotPer90 { get; set; }
        public int? ShotsLeadingToAnotherShot { get; set; }
        public double ShotsLeadingToAnotherShotPer90 { get; set; }
        public int? FoulsDrawnLeadingToShot { get; set; }
        public double FoulsDrawnLeadingToShotPer90 { get; set; }
        public int? GoalCreatingActions { get; set; }
        public double GoalCreatingActionsPer90 { get; set; }
        public int? PassesCompletedLiveBallLeadingToGoal { get; set; }
        public double PassesCompletedLiveBallLeadingToGoalPer90 { get; set; }
        public int? PassesCompletedDeadBallLeadingToGoal { get; set; }
        public double PassesCompletedDeadBallLeadingToGoalPer90 { get; set; }
        public int? DribblesLeadingToGoal { get; set; }
        public double DribblesLeadingToGoalPer90 { get; set; }
        public int? GoalsLeadingToAnotherGoal { get; set; }
        public double ShotsLeadingToAnotherGoalPer90 { get; set; }
        public int? FoulsDrawnLeadingToGoal { get; set; }
        public double FoulsDrawnLeadingToGoalPer90 { get; set; }
        public int? ActionsLeadingToOpponentOwnGoal { get; set; }
        public double ActionsLeadingToOpponentOwnGoalPer90 { get; set; }
        public int? PlayersTackled { get; set; }
        public double PlayersTackledPer90 { get; set; }
        public int? TacklesWon { get; set; }
        public double TacklesWonPer90 { get; set; }
        public double TacklesWonPercentage { get; set; }
        public int? TacklesDefensiveThird { get; set; }
        public int? TacklesMiddleThird { get; set; }
        public int? TacklesAttackingThird { get; set; }
        public int? DribblersTackled { get; set; }
        public int? DribblesContested { get; set; }
        public decimal? AverageDribblersTackledPercentage { get; set; }
        public double DribblersTackledPercentage { get; set; }
        public int? TimesDribbledPast { get; set; }
        public double TimesDribbledPastPer90 { get; set; }
        public int? Pressures { get; set; }
        public double PressuresPer90 { get; set; }
        public int? SuccessfulPressures { get; set; }
        public double SuccessfulPressuresPer90 { get; set; }
        public decimal? AverageSuccessfulPressuresPercentage { get; set; }
        public double SuccessfulPressuresPercentage { get; set; }
        public int? PressuresDefensiveThird { get; set; }
        public int? PressuresMiddleThird { get; set; }
        public int? PressuresAttackingThird { get; set; }
        public int? Blocks { get; set; }
        public double BlocksPer90 { get; set; }
        public int? ShotsBlocked { get; set; }
        public int? ShotsOnTargetBlocked { get; set; }
        public int? PassesBlocked { get; set; }
        public int? Interceptions { get; set; }
        public double InterceptionsPer90 { get; set; }
        public int? PlayersTackledAndInterceptions { get; set; }
        public double PlayersTackledAndInterceptionsPer90 { get; set; }
        public int? Clearances { get; set; }
        public double ClearancesPer90 { get; set; }
        public int? ErrorsLeadingToShot { get; set; }
        public double ErrorsLeadingToShotPer90 { get; set; }
    }
}
