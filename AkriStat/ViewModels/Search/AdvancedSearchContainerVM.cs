using AkriStat.SearchConditions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Search
{
    public class AdvancedSearchContainerVM
    {
        #region Search Conditions
        public string Season { get; set; }
        public string Name { get; set; }
        public List<string> Position { get; set; } = new List<string>();
        public List<int> Nationality { get; set; } = new List<int>();
        public List<int> SecondNationality { get; set; } = new List<int>();
        public List<IntRange> NationalityID { get; set; } = new List<IntRange>();
        public List<IntRange> SecondNationalityID { get; set; } = new List<IntRange>();
        public string Footed { get; set; }
        public IntRange Height { get; set; }
        public IntRange Weight { get; set; }
        public IntRange Value { get; set; }
        [Display(Name = "Weekly Wage")]
        public IntRange WeeklyWage { get; set; }
        [Display(Name = "Contract Expiry")]
        public DateRange ContractExpiry { get; set; }
        public IntRange Age { get; set; }
        [Display(Name = "Games Played")]
        public IntRange GamesPlayed { get; set; }
        [Display(Name = "Minutes Played")]
        public IntRange MinutesPlayed { get; set; }
        public IntRange Goals { get; set; }
        [Display(Name = "Goals per 90")]
        public IntRange GoalsPer90 { get; set; }
        public IntRange Shots { get; set; }
        [Display(Name = "Shots per 90")]
        public IntRange ShotsPer90 { get; set; }
        [Display(Name = "Shots on Target")]
        public IntRange ShotsOnTarget { get; set; }
        [Display(Name = "Shots on Target per 90")]
        public IntRange ShotsOnTargetPer90 { get; set; }
        [Display(Name = "Shots on Target %")]
        public IntRange ShotsOnTargetPercentage { get; set; }
        [Display(Name = "Average Shots on Target %")]
        public IntRange AverageShotsOnTargetPercentage { get; set; }
        [Display(Name = "Shots per Touch")]
        public IntRange ShotsPerTouch { get; set; }
        [Display(Name = "Goals per Shot")]
        public IntRange GoalsPerShot { get; set; }
        [Display(Name = "Penalties Scored")]
        public IntRange PenaltyKicksMade { get; set; }
        [Display(Name = "Penalties Scored per 90")]
        public IntRange PenaltyKicksMadePer90 { get; set; }
        [Display(Name = "Penalties Attempted")]
        public IntRange PenaltyKicksAttempted { get; set; }
        [Display(Name = "Penalty Conversion Rate")]
        public IntRange PenaltyKicksConversionRate { get; set; }
        [Display(Name = "Penalties Attempted per 90")]
        public IntRange PenaltyKicksAttemptedPer90 { get; set; }
        [Display(Name = "xG")]
        public IntRange XG { get; set; }
        [Display(Name = "xG per 90")]
        public IntRange XGPer90 { get; set; }
        [Display(Name = "Non-penalty xG")]
        public IntRange NonPenaltyXG { get; set; }
        [Display(Name = "Non-penalty xG per 90")]
        public IntRange NonPenaltyXGPer90 { get; set; }
        [Display(Name = "Non-penalty xG per Shot")]
        public IntRange NonPenaltyXGPerShot { get; set; }
        [Display(Name = "Goals minus xG")]
        public IntRange GoalsMinusXG { get; set; }
        [Display(Name = "Non-penalty Goals minus xG")]
        public IntRange NonPenaltyGoalsMinusXG { get; set; }
        [Display(Name = "Touches in Defensive Penalty Area")]
        public IntRange TouchesDefensivePenaltyArea { get; set; }
        [Display(Name = "Touches in Defensive Penalty Area per 90")]
        public IntRange TouchesDefensivePenaltyAreaPer90 { get; set; }
        [Display(Name = "Touches in Defensive Third")]
        public IntRange TouchesDefensiveThird { get; set; }
        [Display(Name = "Touches in Defensive Third per 90")]
        public IntRange TouchesDefensiveThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Middle Third")]
        public IntRange TouchesMiddleThird { get; set; }
        [Display(Name = "Touches in Defensive Middle Third per 90")]
        public IntRange TouchesMiddleThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Attacking Third")]
        public IntRange TouchesAttackingThird { get; set; }
        [Display(Name = "Touches in Defensive Attacking Third per 90")]
        public IntRange TouchesAttackingThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Attacking Penalty Area")]
        public IntRange TouchesAttackingPenaltyArea { get; set; }
        [Display(Name = "Touches in Defensive Attacking Penalty Area per 90")]
        public IntRange TouchesAttackingPenaltyAreaPer90 { get; set; }
        public IntRange Touches { get; set; }
        [Display(Name = "Touches per 90")]
        public IntRange TouchesPer90 { get; set; }
        [Display(Name = "Live Ball Touches")]
        public IntRange LiveBallTouches { get; set; }
        [Display(Name = "Live Ball Touches per 90")]
        public IntRange LiveBallTouchesPer90 { get; set; }
        [Display(Name = "Dribbles Attempted")]
        public IntRange DribblesAttempted { get; set; }
        [Display(Name = "Dribbles Attempted per 90")]
        public IntRange DribblesAttemptedPer90 { get; set; }
        [Display(Name = "Successful Dribbles")]
        public IntRange SuccessfulDribbles { get; set; }
        [Display(Name = "Successful Dribbles per 90")]
        public IntRange SuccessfulDribblesPer90 { get; set; }
        [Display(Name = "Successful Dribbles %")]
        public IntRange SuccessfulDribblesPercentage { get; set; }
        [Display(Name = "Average Successful Dribbles %")]
        public IntRange AverageSuccessfulDribblesPercentage { get; set; }
        [Display(Name = "Players Dribbled Past")]
        public IntRange PlayersDribbledPast { get; set; }
        [Display(Name = "Players Dribbled Past per 90")]
        public IntRange PlayersDribbledPastPer90 { get; set; }
        public IntRange Nutmegs { get; set; }
        [Display(Name = "Nutmegs per 90")]
        public IntRange NutmegsPer90 { get; set; }
        [Display(Name = "Carries")]
        public IntRange Carries { get; set; }
        [Display(Name = "Carries per 90")]
        public IntRange CarriesPer90 { get; set; }
        [Display(Name = "Yards Carried")]
        public IntRange YardsCarried { get; set; }
        [Display(Name = "Yards Carried per 90")]
        public IntRange YardsCarriedPer90 { get; set; }
        [Display(Name = "Yards Carried (Progressive)")]
        public IntRange YardsProgressiveCarries { get; set; }
        [Display(Name = "Yards Carried (Progressive) per 90")]
        public IntRange YardsProgressiveCarriesPer90 { get; set; }
        [Display(Name = "Yards per Carry")]
        public IntRange YardsPerCarry { get; set; }
        [Display(Name = "Times Player was Target of Pass")]
        public IntRange WasTargetOfPass { get; set; }
        [Display(Name = "Times Player was Target of Pass per 90")]
        public IntRange WasTargetOfPassPer90 { get; set; }
        [Display(Name = "Passes Received by Player")]
        public IntRange PassesReceived { get; set; }
        [Display(Name = "Passes Receieved by Player per 90")]
        public IntRange PassesReceivedPer90 { get; set; }
        [Display(Name = "Passes Received %")]
        public IntRange PassesReceivedPercentage { get; set; }
        [Display(Name = "Average Passes Received %")]
        public IntRange AveragePassesReceivedPercentage { get; set; }
        public IntRange Miscontrols { get; set; }
        [Display(Name = "Miscontrols per 90")]
        public IntRange MiscontrolsPer90 { get; set; }
        [Display(Name = "Times Dispossessed")]
        public IntRange Dispossessed { get; set; }
        [Display(Name = "Times Dispossessed per 90")]
        public IntRange DispossessedPer90 { get; set; }
        [Display(Name = "Passes Attempted (Live Ball)")]
        public IntRange PassesAttemptedLiveBall { get; set; }
        [Display(Name = "Passes Attempted (Live Ball) per 90")]
        public IntRange PassesAttemptedLiveBallPer90 { get; set; }
        [Display(Name = "Passes Attempted (Dead Ball) per 90")]
        public IntRange PassesAttemptedDeadBall { get; set; }
        [Display(Name = "Passes Attempted (Dead Ball) per 90")]
        public IntRange PassesAttemptedDeadBallPer90 { get; set; }
        [Display(Name = "Passes Attempted (Free Kick)")]
        public IntRange PassesAttemptedFreeKick { get; set; }
        [Display(Name = "Passes Attempted (Free Kick) per 90")]
        public IntRange PassesAttemptedFreeKickPer90 { get; set; }
        [Display(Name = "Passes Completed (Through Ball)")]
        public IntRange PassesCompletedThroughBall { get; set; }
        [Display(Name = "Passes Completed (Through Ball) per 90")]
        public IntRange PassesCompletedThroughBallPer90 { get; set; }
        [Display(Name = "Passes Completed (Under Pressure)")]
        public IntRange PassesCompletedUnderPressure { get; set; }
        [Display(Name = "Passes Completed (Under Pressure) per 90")]
        public IntRange PassesCompletedUnderPressurePer90 { get; set; }
        public IntRange Switches { get; set; }
        [Display(Name = "Switches per 90")]
        public IntRange SwitchesPer90 { get; set; }
        public IntRange Crosses { get; set; }
        [Display(Name = "Crosses per 90")]
        public IntRange CrossesPer90 { get; set; }
        public IntRange CornerKicks { get; set; }
        [Display(Name = "Corner Kicks per 90")]
        public IntRange CornerKicksPer90 { get; set; }
        [Display(Name = "Corner Kicks (Inswinging)")]
        public IntRange CornerKicksInswinging { get; set; }
        [Display(Name = "Corner Kicks (Inswinging) per 90")]
        public IntRange CornerKicksInswingingPer90 { get; set; }
        [Display(Name = "Corner Kicks (Outswinging)")]
        public IntRange CornerKicksOutswinging { get; set; }
        [Display(Name = "Corner Kicks (Outswinging) per 90")]
        public IntRange CornerKicksOutswingingPer90 { get; set; }
        [Display(Name = "Corner Kicks (Straight)")]
        public IntRange CornerKicksStraight { get; set; }
        [Display(Name = "Corner Kicks (Straight) per 90")]
        public IntRange CornerKicksStraightPer90 { get; set; }
        [Display(Name = "Ground Passes")]
        public IntRange PassesGround { get; set; }
        [Display(Name = "Ground Passes per 90")]
        public IntRange PassesGroundPer90 { get; set; }
        [Display(Name = "Low Passes (Below Shoulder)")]
        public IntRange PassesLow { get; set; }
        [Display(Name = "Low Passes per 90")]
        public IntRange PassesLowPer90 { get; set; }
        [Display(Name = "High Passes (Above Shoulder)")]
        public IntRange PassesHigh { get; set; }
        [Display(Name = "High Passes per 90")]
        public IntRange PassesHighPer90 { get; set; }
        [Display(Name = "Left Foot Passes")]
        public IntRange PassesLeftFoot { get; set; }
        [Display(Name = "Passes Left Foot per 90")]
        public IntRange PassesLeftFootPer90 { get; set; }
        [Display(Name = "Right Foot Passes")]
        public IntRange PassesRightFoot { get; set; }
        [Display(Name = "Right Foot Passes per 90")]
        public IntRange PassesRightFootPer90 { get; set; }
        [Display(Name = "Headed Passes")]
        public IntRange PassesHeaded { get; set; }
        [Display(Name = "Headed Passes per 90")]
        public IntRange PassesHeadedPer90 { get; set; }
        [Display(Name = "Throw In Passes")]
        public IntRange PassesThrowIn { get; set; }
        [Display(Name = "Throw In Passes per 90")]
        public IntRange PassesThrowInPer90 { get; set; }
        [Display(Name = "Passes (Other)")]
        public IntRange PassesOther { get; set; }
        [Display(Name = "Passes (Other) per 90")]
        public IntRange PassesOtherPer90 { get; set; }
        [Display(Name = "Offside Passes")]
        public IntRange PassesOffside { get; set; }
        [Display(Name = "Offside Passes per 90")]
        public IntRange PassesOffsidePer90 { get; set; }
        [Display(Name = "Out of Bounds Passes")]
        public IntRange PassesOutOfBounds { get; set; }
        [Display(Name = "Out of Bounds Passes per 90")]
        public IntRange PassesOutOfBoundsPer90 { get; set; }
        [Display(Name = "Passes Attempted (Intercepted)")]
        public IntRange PassesAttemptedIntercepted { get; set; }
        [Display(Name = "Passes Attempted (Intercepted) per 90")]
        public IntRange PassesAttemptedInterceptedPer90 { get; set; }
        [Display(Name = "Passes Attempted (Blocked)")]
        public IntRange PassesAttemptedBlocked { get; set; }
        [Display(Name = "Passes Attempted (Blocked) per 90")]
        public IntRange PassesAttemptedBlockedPer90 { get; set; }
        [Display(Name = "Passes Completed")]
        public IntRange PassesCompleted { get; set; }
        [Display(Name = "Passes Completed per 90")]
        public IntRange PassesCompletedPer90 { get; set; }
        [Display(Name = "Passes Attempted")]
        public IntRange PassesAttempted { get; set; }
        [Display(Name = "Passes Attempted per 90")]
        public IntRange PassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Passes Completed %")]
        public IntRange AveragePassesCompletedPercentage { get; set; }
        [Display(Name = "Passes Completed %")]
        public IntRange PassesCompletedPercentage { get; set; }
        [Display(Name = "Yards Passed")]
        public IntRange YardsPassed { get; set; }
        [Display(Name = "Yards Passed per 90")]
        public IntRange YardsPassedPer90 { get; set; }
        [Display(Name = "Yards Passed Progressive")]
        public IntRange YardsPassedProgressive { get; set; }
        [Display(Name = "Yards Passed Progressive per 90")]
        public IntRange YardsPassedProgressivePer90 { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed")]
        public IntRange ShortPassesCompleted { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed per 90")]
        public IntRange ShortPassesCompletedPer90 { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Attempted")]
        public IntRange ShortPassesAttempted { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Attempted per 90")]
        public IntRange ShortPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Short Passes (5-15 yds) Completed %")]
        public IntRange AverageShortPassesCompletedPercentage { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed %")]
        public IntRange ShortPassesCompletedPercentage { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed")]
        public IntRange MediumPassesCompleted { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed per 90")]
        public IntRange MediumPassesCompletedPer90 { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Attempted")]
        public IntRange MediumPassesAttempted { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Attempted per 90")]
        public IntRange MediumPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Medium Passes (15-30 yds) Completed %")]
        public IntRange AverageMediumPassesCompletedPercentage { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed %")]
        public IntRange MediumPassesCompletedPercentage { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed")]
        public IntRange LongPassesCompleted { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed per 90")]
        public IntRange LongPassesCompletedPer90 { get; set; }
        [Display(Name = "Long Passes (30+ yds) Attempted")]
        public IntRange LongPassesAttempted { get; set; }
        [Display(Name = "Long Passes (30+ yds) Attempted per 90")]
        public IntRange LongPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Long Passes (30+ yds) Completed %")]
        public IntRange AverageLongPassesCompletedPercentage { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed %")]
        public IntRange LongPassesCompletedPercentage { get; set; }
        public IntRange Assists { get; set; }
        [Display(Name = "Assists per 90")]
        public IntRange AssistsPer90 { get; set; }
        [Display(Name = "xA")]
        public IntRange XGAssisted { get; set; }
        [Display(Name = "xA per 90")]
        public IntRange XGAssistedPer90 { get; set; }
        [Display(Name = "Key Passes")]
        public IntRange KeyPasses { get; set; }
        [Display(Name = "Key Passes per 90")]
        public IntRange KeyPassesPer90 { get; set; }
        [Display(Name = "Chances Created")]
        public IntRange ChancesCreated { get; set; }
        [Display(Name = "Chances Created per 90")]
        public IntRange ChancesCreatedPer90 { get; set; }
        [Display(Name = "Passes Into Final Third")]
        public IntRange PassesIntoFinalThird { get; set; }
        [Display(Name = "Passes Into Final Third per 90")]
        public IntRange PassesIntoFinalThirdPer90 { get; set; }
        [Display(Name = "Passes Into Penalty Area")]
        public IntRange PassesIntoPenaltyArea { get; set; }
        [Display(Name = "Passes Into Penalty Area per 90")]
        public IntRange PassesIntoPenaltyAreaPer90 { get; set; }
        [Display(Name = "Cross Into Penalty Area")]
        public IntRange CrossesIntoPenaltyArea { get; set; }
        [Display(Name = "Crosses Into Penalty Area per 90")]
        public IntRange CrossesIntoPenaltyAreaPer90 { get; set; }
        [Display(Name = "Progressive Passes per 90")]
        public IntRange ProgressivePasses { get; set; }
        [Display(Name = "Progressive Passes per 90")]
        public IntRange ProgressivePassesPer90 { get; set; }
        [Display(Name = "Average Progressive Passes %")]
        public IntRange AverageProgressivePassesPercentage { get; set; }
        [Display(Name = "Progressive Passes %")]
        public IntRange ProgressivePassesPercentage { get; set; }
        [Display(Name = "Yellow Cards")]
        public IntRange YellowCards { get; set; }
        [Display(Name = "Red Cards")]
        public IntRange RedCards { get; set; }
        public IntRange Fouls { get; set; }
        [Display(Name = "Fouls per 90")]
        public IntRange FoulsPer90 { get; set; }
        [Display(Name = "Fouls Drawn")]
        public IntRange FoulsDrawn { get; set; }
        [Display(Name = "Fouls Drawn per 90")]
        public IntRange FoulsDrawnPer90 { get; set; }
        public IntRange Offsides { get; set; }
        [Display(Name = "Offsides per 90")]
        public IntRange OffsidesPer90 { get; set; }
        [Display(Name = "Penalty Kicks Conceded")]
        public IntRange PenaltyKicksConceded { get; set; }
        [Display(Name = "Penalty Kicks Conceded per 90")]
        public IntRange PenaltyKicksConcededPer90 { get; set; }
        [Display(Name = "Own Goals")]
        public IntRange OwnGoals { get; set; }
        [Display(Name = "Own Goals per 90")]
        public IntRange OwnGoalsPer90 { get; set; }
        [Display(Name = "Loose Balls Recovered")]
        public IntRange LooseBallsRecovered { get; set; }
        [Display(Name = "Loose Balls Recovered per 90")]
        public IntRange LooseBallsRecoveredPer90 { get; set; }
        [Display(Name = "Aerial Duals Won")]
        public IntRange AerialDualsWon { get; set; }
        [Display(Name = "Aerial Duals Won per 90")]
        public IntRange AerialDualsWonPer90 { get; set; }
        [Display(Name = "Aerial Duals Lost")]
        public IntRange AerialDualsLost { get; set; }
        [Display(Name = "Aerial Duals Won per 90")]
        public IntRange AerialDualsLostPer90 { get; set; }
        [Display(Name = "Average Aerial Duals Won %")]
        public IntRange AverageAerialDualsWonPercentage { get; set; }
        [Display(Name = "Aerial Duals Won %")]
        public IntRange AerialDualsWonPercentage { get; set; }
        [Display(Name = "Shots on Target Faced")]
        public IntRange GkShotsOnTargetFacedPer90 { get; set; }
        [Display(Name = "Goals Conceded")]
        public IntRange GkGoalsConceded { get; set; }
        [Display(Name = "Goals Conceded per 90")]
        public IntRange GkGoalsConcededPer90 { get; set; }
        [Display(Name = "Saves")]
        public IntRange GkSaves { get; set; }
        [Display(Name = "Saves per 90")]
        public IntRange GkSavesPer90 { get; set; }
        [Display(Name = "Average Saves %")]
        public IntRange GkAverageSavesPercentage { get; set; }
        [Display(Name = "Saves %")]
        public IntRange GkSavesPercentage { get; set; }
        [Display(Name = "Clean Sheets")]
        public IntRange GkCleanSheets { get; set; }
        [Display(Name = "Post Shot xG")]
        public IntRange GkPostShotXG { get; set; }
        [Display(Name = "Post Shot cG per 90")]
        public IntRange GkPostShotXGPer90 { get; set; }
        [Display(Name = "Passes Completed >40 yds")]
        public IntRange GkPassesCompletedOver40Yards { get; set; }
        [Display(Name = "Passes Completed >40 yds per 90")]
        public IntRange GkPassesCompletedOver40YardsPer90 { get; set; }
        [Display(Name = "Passes Attempted >40 yds")]
        public IntRange GkPassesAttemptedOver40Yards { get; set; }
        [Display(Name = "Passes Attempted >40 yds per 90")]
        public IntRange GkPassesAttemptedOver40YardsPer90 { get; set; }
        [Display(Name = "Average Passes Completed >40 yds %")]
        public IntRange GkAveragePassesCompletedOver40YardsPercentage { get; set; }
        [Display(Name = "Passes Completed >40 yds %")]
        public IntRange GkPassesCompletedOver40YardsPercentage { get; set; }
        [Display(Name = "Throws Attempted")]
        public IntRange GkThrowsAttempted { get; set; }
        [Display(Name = "Throws Attempted per 90")]
        public IntRange GkThrowsAttemptedPer90 { get; set; }
        [Display(Name = "Average Passes Attempted >40 yds %")]
        public IntRange GkAveragePassesAttemptedOver40YardsPercentage { get; set; }
        [Display(Name = "Passes Attempted >40 yds %")]
        public IntRange GkPassesAttemptedOver40YardsPercentage { get; set; }
        [Display(Name = "Average Pass Length (yds)")]
        public IntRange GkAverageYardsPassLength { get; set; }
        [Display(Name = "Goal Kicks Attempted")]
        public IntRange GkGoalKicksAttempted { get; set; }
        [Display(Name = "Goal Kicks Attempted per 90")]
        public IntRange GkGoalKicksAttemptedPer90 { get; set; }
        [Display(Name = "Avg Goal Kicks Launched %")]
        public IntRange GkAverageGoalKicksLaunchedPercentage { get; set; }
        [Display(Name = "Goal Kicks Avg yds")]
        public IntRange GkGoalKickAverageYards { get; set; }
        [Display(Name = "Opponent Crosses Attempted")]
        public IntRange GkOpponentCrossesAttempted { get; set; }
        [Display(Name = "Avg Crosses Stopped %")]
        public IntRange GkAverageCrossesStoppedPercentage { get; set; }
        [Display(Name = "Opponent Crosses Stopped %")]
        public IntRange GkOpponentCrossesStoppedPercentage { get; set; }
        [Display(Name = "Defensive Actions Outside Box")]
        public IntRange GkDefensiveActionsOutsidePenaltyArea { get; set; }
        [Display(Name = "Defensive Actions Outside Box per 90")]
        public IntRange GkDefensiveActionsOutsidePenaltyAreaPer90 { get; set; }
        [Display(Name = "Avg Distance From Goal for Defensive Action")]
        public IntRange GkAverageDistanceFromGoalForDefensiveActions { get; set; }
        [Display(Name = "Shot Creating Actions")]
        public IntRange ShotCreatingActions { get; set; }
        [Display(Name = "Shot Creating Actions per 90")]
        public IntRange ShotCreatingActionsPer90 { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Shot")]
        public IntRange PassesCompletedLiveBallLeadingToShot { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Shot per 90")]
        public IntRange PassesCompletedLiveBallLeadingToShotPer90 { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Shot")]
        public IntRange PassesCompletedDeadBallLeadingToShot { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Shot per 90")]
        public IntRange PassesCompletedDeadBallLeadingToShotPer90 { get; set; }
        [Display(Name = "Dribbles Leading to Shot")]
        public IntRange DribblesLeadingToShot { get; set; }
        [Display(Name = "Dribbles Leading to Shot per 90")]
        public IntRange DribblesLeadingToShotPer90 { get; set; }
        [Display(Name = "Shots Leading to Another Shot")]
        public IntRange ShotsLeadingToAnotherShot { get; set; }
        [Display(Name = "Shots Leading to Another Shot per 90")]
        public IntRange ShotsLeadingToAnotherShotPer90 { get; set; }
        [Display(Name = "Fouls Drawn Leading to Shot")]
        public IntRange FoulsDrawnLeadingToShot { get; set; }
        [Display(Name = "Fouls Drawn Leading to Shot per 90")]
        public IntRange FoulsDrawnLeadingToShotPer90 { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Goal")]
        public IntRange PassesCompletedLiveBallLeadingToGoal { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Goal per 90")]
        public IntRange PassesCompletedLiveBallLeadingToGoalPer90 { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Goal")]
        public IntRange PassesCompletedDeadBallLeadingToGoal { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Goal per 90")]
        public IntRange PassesCompletedDeadBallLeadingToGoalPer90 { get; set; }
        [Display(Name = "Dribbles Leading to Goal")]
        public IntRange DribblesLeadingToGoal { get; set; }
        [Display(Name = "Dribbles Leading to Goal per 90")]
        public IntRange DribblesLeadingToGoalPer90 { get; set; }
        [Display(Name = "Shots Leading to Another Shot")]
        public IntRange ShotsLeadingToAnotherGoal { get; set; }
        [Display(Name = "Shots Leading to Another Goal per 90")]
        public IntRange ShotsLeadingToAnotherGoalPer90 { get; set; }
        [Display(Name = "Fouls Drawn Leading to Goal")]
        public IntRange FoulsDrawnLeadingToGoal { get; set; }
        [Display(Name = "Fouls Drawn Leading to Goal per 90")]
        public IntRange FoulsDrawnLeadingToGoalPer90 { get; set; }
        [Display(Name = "Actions Leading to Opponent Own Goal")]
        public IntRange ActionsLeadingToOpponentOwnGoal { get; set; }
        [Display(Name = "Actions Leading to Opponent Own Goal per 90")]
        public IntRange ActionsLeadingToOpponentOwnGoalPer90 { get; set; }
        [Display(Name = "Players Tackled")]
        public IntRange PlayersTackled { get; set; }
        [Display(Name = "Players Tackled per 90")]
        public IntRange PlayersTackledPer90 { get; set; }
        [Display(Name = "Tackles Won")]
        public IntRange TacklesWon { get; set; }
        [Display(Name = "Tackles Won per 90")]
        public IntRange TacklesWonPer90 { get; set; }
        [Display(Name = "Tackles Defensive Third")]
        public IntRange TacklesDefensiveThird { get; set; }
        [Display(Name = "Tackles Middle Third")]
        public IntRange TacklesMiddleThird { get; set; }
        [Display(Name = "Tackles Attacking Third")]
        public IntRange TacklesAttackingThird { get; set; }
        [Display(Name = "Dribblers Tackled")]
        public IntRange DribblersTackled { get; set; }
        [Display(Name = "Dribbles Contested")]
        public IntRange DribblesContested { get; set; }
        [Display(Name = "Avg Dribblers Tackled %")]
        public IntRange AverageDribblersTackledPercentage { get; set; }
        [Display(Name = "Dribblers Tackled %")]
        public IntRange DribblersTackledPercentage { get; set; }
        [Display(Name = "Times Dribbled Past")]
        public IntRange TimesDribbledPast { get; set; }
        [Display(Name = "Time Dribbled Past per 90")]
        public IntRange TimesDribbledPastPer90 { get; set; }
        public IntRange Pressures { get; set; }
        [Display(Name = "Pressures per 90")]
        public IntRange PressuresPer90 { get; set; }
        [Display(Name = "Successful Pressures")]
        public IntRange SuccessfulPressures { get; set; }
        [Display(Name = "Successful Pressures per 90")]
        public IntRange SuccessfulPressuresPer90 { get; set; }
        [Display(Name = "Avg Successful Pressures %")]
        public IntRange AverageSuccessfulPressuresPercentage { get; set; }
        [Display(Name = "Successful Pressures %")]
        public IntRange SuccessfulPressuresPercentage { get; set; }
        [Display(Name = "Pressures Defensive Third")]
        public IntRange PressuresDefensiveThird { get; set; }
        [Display(Name = "Pressures Middle Third")]
        public IntRange PressuresMiddleThird { get; set; }
        [Display(Name = "Pressures Attacking Third")]
        public IntRange PressuresAttackingThird { get; set; }
        public IntRange Blocks { get; set; }
        [Display(Name = "Blocks per 90")]
        public IntRange BlocksPer90 { get; set; }
        [Display(Name = "Shots Blocked")]
        public IntRange ShotsBlocked { get; set; }
        [Display(Name = "Shots on Target Blocked")]
        public IntRange ShotsOnTargetBlocked { get; set; }
        [Display(Name = "Passes Blocked")]
        public IntRange PassesBlocked { get; set; }
        public IntRange Interceptions { get; set; }
        [Display(Name = "Interceptions per 90")]
        public IntRange InterceptionsPer90 { get; set; }
        [Display(Name = "Players Tackled + Interceptions")]
        public IntRange PlayersTackledAndInterceptions { get; set; }
        [Display(Name = "Players Tackled + Interceptions per 90")]
        public IntRange PlayersTackledAndInterceptionsPer90 { get; set; }
        public IntRange Clearances { get; set; }
        [Display(Name = "Clearances per 90")]
        public IntRange ClearancesPer90 { get; set; }
        [Display(Name = "Errors Leading to Shot")]
        public IntRange ErrorsLeadingToShot { get; set; }
        [Display(Name = "Errors Leading to Shot per 90")]
        public IntRange ErrorsLeadingToShotPer90 { get; set; }
        #endregion

        public List<AdvancedSearchResultVM> SearchResults { get; set; }
    }
}
