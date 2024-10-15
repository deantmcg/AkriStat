using AkriStat.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Search
{
    public class AdvancedSearchResultVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public string FacePictureUrl { get; set; }
        public string Position { get; set; }
        public string PositionDisplay { get; set; }
        public int NationalityID { get; set; }
        public string NationalityFlagUrl { get; set; }
        public int SecondNationalityID { get; set; }
        public string SecondNationalityFlagUrl { get; set; }
        public string Footed { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}", NullDisplayText = "?")]
        public decimal? Value { get; set; }
        public string ValueString
        {
            get
            {
                if (Value == null)
                    return "?";
                Formatter formatter = new Formatter();
                return formatter.GetCurrencyString(Value.Value);
            }
        }
        [Display(Name = "Weekly Wage"), DisplayFormat(DataFormatString = "{0:C0}", NullDisplayText = "?")]
        public decimal WeeklyWage { get; set; }
        [Display(Name = "Contract Expiry"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "?")]
        public DateTime? ContractExpiry { get; set; }
        [Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "?")]
        public DateTime DateOfBirth { get; set; }
        public int Age 
        {
            get
            {
                DateTime dtNow = new DateTime(2020, 5, 30);
                int years = new DateTime(dtNow.Subtract(DateOfBirth).Ticks).Year - 1;
                return years;
            }
        }
        [Display(Name = "Games Played")]
        public int GamesPlayed { get; set; }
        [Display(Name = "Minutes Played")]
        public int MinutesPlayed { get; set; }
        public int Goals { get; set; }
        [Display(Name = "Goals per 90")]
        public double GoalsPer90 { get; set; }
        public int Shots { get; set; }
        [Display(Name = "Shots per 90")]
        public double ShotsPer90 { get; set; }
        [Display(Name = "Shots on Target")]
        public int ShotsOnTarget { get; set; }
        [Display(Name = "Shots on Target per 90")]
        public double ShotsOnTargetPer90 { get; set; }
        [Display(Name = "Shots on Target %")]
        public double ShotsOnTargetPercentage { get; set; }
        [Display(Name = "Average Shots on Target %")]
        public decimal AverageShotsOnTargetPercentage { get; set; }
        [Display(Name = "Shots per Touch")]
        public double ShotsPerTouch { get; set; }
        [Display(Name = "Goals per Shot")]
        public double GoalsPerShot { get; set; }
        [Display(Name = "Penalties Scored")]
        public int PenaltyKicksMade { get; set; }
        [Display(Name = "Penalties Scored per 90")]
        public double PenaltyKicksMadePer90 { get; set; }
        [Display(Name = "Penalties Attempted")]
        public int PenaltyKicksAttempted { get; set; }
        [Display(Name = "Penalty Conversion Rate")]
        public double PenaltyKicksConversionRate { get; set; }
        [Display(Name = "Penalties Attempted per 90")]
        public double PenaltyKicksAttemptedPer90 { get; set; }
        [Display(Name = "xG")]
        public decimal XG { get; set; }
        [Display(Name = "xG per 90")]
        public double XGPer90 { get; set; }
        [Display(Name = "Non-penalty xG")]
        public decimal NonPenaltyXG { get; set; }
        [Display(Name = "Non-penalty xG per 90")]
        public double NonPenaltyXGPer90 { get; set; }
        [Display(Name = "Non-penalty xG per Shot")]
        public double NonPenaltyXGPerShot { get; set; }
        [Display(Name = "Goals minus xG")]
        public decimal GoalsMinusXG { get; set; }
        [Display(Name = "Non-penalty Goals minus xG")]
        public decimal NonPenaltyGoalsMinusXG { get; set; }
        [Display(Name = "Touches in Defensive Penalty Area")]
        public int TouchesDefensivePenaltyArea { get; set; }
        [Display(Name = "Touches in Defensive Penalty Area per 90")]
        public double TouchesDefensivePenaltyAreaPer90 { get; set; }
        [Display(Name = "Touches in Defensive Third")]
        public int TouchesDefensiveThird { get; set; }
        [Display(Name = "Touches in Defensive Third per 90")]
        public double TouchesDefensiveThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Middle Third")]
        public int TouchesMiddleThird { get; set; }
        [Display(Name = "Touches in Defensive Middle Third per 90")]
        public double TouchesMiddleThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Attacking Third")]
        public int TouchesAttackingThird { get; set; }
        [Display(Name = "Touches in Defensive Attacking Third per 90")]
        public double TouchesAttackingThirdPer90 { get; set; }
        [Display(Name = "Touches in Defensive Attacking Penalty Area")]
        public int TouchesAttackingPenaltyArea { get; set; }
        [Display(Name = "Touches in Defensive Attacking Penalty Area per 90")]
        public double TouchesAttackingPenaltyAreaPer90 { get; set; }
        public int Touches { get; set; }
        [Display(Name = "Touches per 90")]
        public double TouchesPer90 { get; set; }
        [Display(Name = "Live Ball Touches")]
        public int LiveBallTouches { get; set; }
        [Display(Name = "Live Ball Touches per 90")]
        public double LiveBallTouchesPer90 { get; set; }
        [Display(Name = "Dribbles Attempted")]
        public int DribblesAttempted { get; set; }
        [Display(Name = "Dribbles Attempted per 90")]
        public double DribblesAttemptedPer90 { get; set; }
        [Display(Name = "Successful Dribbles")]
        public int SuccessfulDribbles { get; set; }
        [Display(Name = "Successful Dribbles per 90")]
        public double SuccessfulDribblesPer90 { get; set; }
        [Display(Name = "Successful Dribbles %")]
        public double SuccessfulDribblesPercentage { get; set; }
        [Display(Name = "Average Successful Dribbles %")]
        public decimal AverageSuccessfulDribblesPercentage { get; set; }
        [Display(Name = "Players Dribbled Past")]
        public int PlayersDribbledPast { get; set; }
        [Display(Name = "Players Dribbled Past per 90")]
        public double PlayersDribbledPastPer90 { get; set; }
        public int Nutmegs { get; set; }
        [Display(Name = "Nutmegs per 90")]
        public double NutmegsPer90 { get; set; }
        [Display(Name = "Carries")]
        public int Carries { get; set; }
        [Display(Name = "Carries per 90")]
        public double CarriesPer90 { get; set; }
        [Display(Name = "Yards Carried")]
        public int YardsCarried { get; set; }
        [Display(Name = "Yards Carried per 90")]
        public double YardsCarriedPer90 { get; set; }
        [Display(Name = "Yards Carried (Progressive)")]
        public int YardsProgressiveCarries { get; set; }
        [Display(Name = "Yards Carried (Progressive) per 90")]
        public double YardsProgressiveCarriesPer90 { get; set; }
        [Display(Name = "Yards per Carry")]
        public double YardsPerCarry { get; set; }
        [Display(Name = "Times Player was Target of Pass")]
        public int WasTargetOfPass { get; set; }
        [Display(Name = "Times Player was Target of Pass per 90")]
        public double WasTargetOfPassPer90 { get; set; }
        [Display(Name = "Passes Received by Player")]
        public int PassesReceived { get; set; }
        [Display(Name = "Passes Receieved by Player per 90")]
        public double PassesReceivedPer90 { get; set; }
        [Display(Name = "Passes Received %")]
        public double PassesReceivedPercentage { get; set; }
        [Display(Name = "Average Passes Received %")]
        public decimal AveragePassesReceivedPercentage { get; set; }
        public int Miscontrols { get; set; }
        [Display(Name = "Miscontrols per 90")]
        public double MiscontrolsPer90 { get; set; }
        [Display(Name = "Times Dispossessed")]
        public int Dispossessed { get; set; }
        [Display(Name = "Times Dispossessed per 90")]
        public double DispossessedPer90 { get; set; }
        [Display(Name = "Passes Attempted (Live Ball)")]
        public int PassesAttemptedLiveBall { get; set; }
        [Display(Name = "Passes Attempted (Live Ball) per 90")]
        public double PassesAttemptedLiveBallPer90 { get; set; }
        [Display(Name = "Passes Attempted (Dead Ball) per 90")]
        public int PassesAttemptedDeadBall { get; set; }
        [Display(Name = "Passes Attempted (Dead Ball) per 90")]
        public double PassesAttemptedDeadBallPer90 { get; set; }
        [Display(Name = "Passes Attempted (Free Kick)")]
        public int PassesAttemptedFreeKick { get; set; }
        [Display(Name = "Passes Attempted (Free Kick) per 90")]
        public double PassesAttemptedFreeKickPer90 { get; set; }
        [Display(Name = "Passes Completed (Through Ball)")]
        public int PassesCompletedThroughBall { get; set; }
        [Display(Name = "Passes Completed (Through Ball) per 90")]
        public double PassesCompletedThroughBallPer90 { get; set; }
        [Display(Name = "Passes Completed (Under Pressure)")]
        public int PassesCompletedUnderPressure { get; set; }
        [Display(Name = "Passes Completed (Under Pressure) per 90")]
        public double PassesCompletedUnderPressurePer90 { get; set; }
        public int Switches { get; set; }
        [Display(Name = "Switches per 90")]
        public double SwitchesPer90 { get; set; }
        public int Crosses { get; set; }
        [Display(Name = "Crosses per 90")]
        public double CrossesPer90 { get; set; }
        [Display(Name = "Corner Kicks")]
        public int CornerKicks { get; set; }
        [Display(Name = "Corner Kicks per 90")]
        public double CornerKicksPer90 { get; set; }
        [Display(Name = "Corner Kicks (Inswinging)")]
        public int CornerKicksInswinging { get; set; }
        [Display(Name = "Corner Kicks (Inswinging) per 90")]
        public double CornerKicksInswingingPer90 { get; set; }
        [Display(Name = "Corner Kicks (Outswinging)")]
        public int CornerKicksOutswinging { get; set; }
        [Display(Name = "Corner Kicks (Outswinging) per 90")]
        public double CornerKicksOutswingingPer90 { get; set; }
        [Display(Name = "Corner Kicks (Straight)")]
        public int CornerKicksStraight { get; set; }
        [Display(Name = "Corner Kicks (Straight) per 90")]
        public double CornerKicksStraightPer90 { get; set; }
        [Display(Name = "Ground Passes")]
        public int PassesGround { get; set; }
        [Display(Name = "Ground Passes per 90")]
        public double PassesGroundPer90 { get; set; }
        [Display(Name = "Low Passes (Below Shoulder)")]
        public int PassesLow { get; set; }
        [Display(Name = "Low Passes per 90")]
        public double PassesLowPer90 { get; set; }
        [Display(Name = "High Passes (Above Shoulder)")]
        public int PassesHigh { get; set; }
        [Display(Name = "High Passes per 90")]
        public double PassesHighPer90 { get; set; }
        [Display(Name = "Left Foot Passes")]
        public int PassesLeftFoot { get; set; }
        [Display(Name = "Passes Left Foot per 90")]
        public double PassesLeftFootPer90 { get; set; }
        [Display(Name = "Right Foot Passes")]
        public int PassesRightFoot { get; set; }
        [Display(Name = "Right Foot Passes per 90")]
        public double PassesRightFootPer90 { get; set; }
        [Display(Name = "Headed Passes")]
        public int PassesHeaded { get; set; }
        [Display(Name = "Headed Passes per 90")]
        public double PassesHeadedPer90 { get; set; }
        [Display(Name = "Throw In Passes")]
        public int PassesThrowIn { get; set; }
        [Display(Name = "Throw In Passes per 90")]
        public double PassesThrowInPer90 { get; set; }
        [Display(Name = "Passes (Other)")]
        public int PassesOther { get; set; }
        [Display(Name = "Passes (Other) per 90")]
        public double PassesOtherPer90 { get; set; }
        [Display(Name = "Offside Passes")]
        public int PassesOffside { get; set; }
        [Display(Name = "Offside Passes per 90")]
        public double PassesOffsidePer90 { get; set; }
        [Display(Name = "Out of Bounds Passes")]
        public int PassesOutOfBounds { get; set; }
        [Display(Name = "Out of Bounds Passes per 90")]
        public double PassesOutOfBoundsPer90 { get; set; }
        [Display(Name = "Passes Attempted (Intercepted)")]
        public int PassesAttemptedIntercepted { get; set; }
        [Display(Name = "Passes Attempted (Intercepted) per 90")]
        public double PassesAttemptedInterceptedPer90 { get; set; }
        [Display(Name = "Passes Attempted (Blocked)")]
        public int PassesAttemptedBlocked { get; set; }
        [Display(Name = "Passes Attempted (Blocked) per 90")]
        public double PassesAttemptedBlockedPer90 { get; set; }
        [Display(Name = "Passes Completed")]
        public int PassesCompleted { get; set; }
        [Display(Name = "Passes Completed per 90")]
        public double PassesCompletedPer90 { get; set; }
        [Display(Name = "Passes Attempted")]
        public int PassesAttempted { get; set; }
        [Display(Name = "Passes Attempted per 90")]
        public double PassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Passes Completed %")]
        public decimal AveragePassesCompletedPercentage { get; set; }
        [Display(Name = "Passes Completed %")]
        public double PassesCompletedPercentage { get; set; }
        [Display(Name = "Yards Passed")]
        public int YardsPassed { get; set; }
        [Display(Name = "Yards Passed per 90")]
        public double YardsPassedPer90 { get; set; }
        [Display(Name = "Yards Passed Progressive")]
        public int YardsPassedProgressive { get; set; }
        [Display(Name = "Yards Passed Progressive per 90")]
        public double YardsPassedProgressivePer90 { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed")]
        public int ShortPassesCompleted { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed per 90")]
        public double ShortPassesCompletedPer90 { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Attempted")]
        public int ShortPassesAttempted { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Attempted per 90")]
        public double ShortPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Short Passes (5-15 yds) Completed %")]
        public decimal AverageShortPassesCompletedPercentage { get; set; }
        [Display(Name = "Short Passes (5-15 yds) Completed %")]
        public double ShortPassesCompletedPercentage { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed")]
        public int MediumPassesCompleted { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed per 90")]
        public double MediumPassesCompletedPer90 { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Attempted")]
        public int MediumPassesAttempted { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Attempted per 90")]
        public double MediumPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Medium Passes (15-30 yds) Completed %")]
        public decimal AverageMediumPassesCompletedPercentage { get; set; }
        [Display(Name = "Medium Passes (15-30 yds) Completed %")]
        public double MediumPassesCompletedPercentage { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed")]
        public int LongPassesCompleted { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed per 90")]
        public double LongPassesCompletedPer90 { get; set; }
        [Display(Name = "Long Passes (30+ yds) Attempted")]
        public int LongPassesAttempted { get; set; }
        [Display(Name = "Long Passes (30+ yds) Attempted per 90")]
        public double LongPassesAttemptedPer90 { get; set; }
        [Display(Name = "Average Long Passes (30+ yds) Completed %")]
        public decimal AverageLongPassesCompletedPercentage { get; set; }
        [Display(Name = "Long Passes (30+ yds) Completed %")]
        public double LongPassesCompletedPercentage { get; set; }
        public int Assists { get; set; }
        [Display(Name = "Assists per 90")]
        public double AssistsPer90 { get; set; }
        [Display(Name = "xA")]
        public decimal XGAssisted { get; set; }
        [Display(Name = "xA per 90")]
        public double XGAssistedPer90 { get; set; }
        [Display(Name = "Key Passes")]
        public int KeyPasses { get; set; }
        [Display(Name = "Key Passes per 90")]
        public double KeyPassesPer90 { get; set; }
        [Display(Name = "Chances Created")]
        public int ChancesCreated { get; set; }
        [Display(Name = "Chances Created per 90")]
        public double ChancesCreatedPer90 { get; set; }
        [Display(Name = "Passes Into Final Third")]
        public int PassesIntoFinalThird { get; set; }
        [Display(Name = "Passes Into Final Third per 90")]
        public double PassesIntoFinalThirdPer90 { get; set; }
        [Display(Name = "Passes Into Penalty Area")]
        public int PassesIntoPenaltyArea { get; set; }
        [Display(Name = "Passes Into Penalty Area per 90")]
        public double PassesIntoPenaltyAreaPer90 { get; set; }
        [Display(Name = "Cross Into Penalty Area")]
        public int CrossesIntoPenaltyArea { get; set; }
        [Display(Name = "Crosses Into Penalty Area per 90")]
        public double CrossesIntoPenaltyAreaPer90 { get; set; }
        [Display(Name = "Progressive Passes per 90")]
        public int ProgressivePasses { get; set; }
        [Display(Name = "Progressive Passes per 90")]
        public double ProgressivePassesPer90 { get; set; }
        [Display(Name = "Average Progressive Passes %")]
        public decimal AverageProgressivePassesPercentage { get; set; }
        [Display(Name = "Progressive Passes %")]
        public double ProgressivePassesPercentage { get; set; }
        [Display(Name = "Yellow Cards")]
        public int YellowCards { get; set; }
        [Display(Name = "Red Cards")]
        public int RedCards { get; set; }
        public int Fouls { get; set; }
        [Display(Name = "Fouls per 90")]
        public double FoulsPer90 { get; set; }
        [Display(Name = "Fouls Drawn")]
        public int FoulsDrawn { get; set; }
        [Display(Name = "Fouls Drawn per 90")]
        public double FoulsDrawnPer90 { get; set; }
        public int Offsides { get; set; }
        [Display(Name = "Offsides per 90")]
        public double OffsidesPer90 { get; set; }
        [Display(Name = "Penalty Kicks Conceded")]
        public int PenaltyKicksConceded { get; set; }
        [Display(Name = "Penalty Kicks Conceded per 90")]
        public double PenaltyKicksConcededPer90 { get; set; }
        [Display(Name = "Own Goals")]
        public int OwnGoals { get; set; }
        [Display(Name = "Own Goals per 90")]
        public double OwnGoalsPer90 { get; set; }
        [Display(Name = "Loose Balls Recovered")]
        public int LooseBallsRecovered { get; set; }
        [Display(Name = "Loose Balls Recovered per 90")]
        public double LooseBallsRecoveredPer90 { get; set; }
        [Display(Name = "Aerial Duals Won")]
        public int AerialDualsWon { get; set; }
        [Display(Name = "Aerial Duals Won per 90")]
        public double AerialDualsWonPer90 { get; set; }
        [Display(Name = "Aerial Duals Lost")]
        public int AerialDualsLost { get; set; }
        [Display(Name = "Aerial Duals Won per 90")]
        public double AerialDualsLostPer90 { get; set; }
        [Display(Name = "Average Aerial Duals Won %")]
        public decimal AverageAerialDualsWonPercentage { get; set; }
        [Display(Name = "Aerial Duals Won %")]
        public double AerialDualsWonPercentage { get; set; }
        [Display(Name = "Shots on Target Faced")]
        public double GkShotsOnTargetFacedPer90 { get; set; }
        [Display(Name = "Goals Conceded")]
        public int GkGoalsConceded { get; set; }
        [Display(Name = "Goals Conceded per 90")]
        public double GkGoalsConcededPer90 { get; set; }
        [Display(Name = "Saves")]
        public int GkSaves { get; set; }
        [Display(Name = "Saves per 90")]
        public double GkSavesPer90 { get; set; }
        [Display(Name = "Average Saves %")]
        public decimal GkAverageSavesPercentage { get; set; }
        [Display(Name = "Saves %")]
        public double GkSavesPercentage { get; set; }
        [Display(Name = "Clean Sheets")]
        public int GkCleanSheets { get; set; }
        [Display(Name = "Post Shot xG")]
        public decimal GkPostShotXG { get; set; }
        [Display(Name = "Post Shot cG per 90")]
        public double GkPostShotXGPer90 { get; set; }
        [Display(Name = "Passes Completed >40 yds")]
        public int GkPassesCompletedOver40Yards { get; set; }
        [Display(Name = "Passes Completed >40 yds per 90")]
        public double GkPassesCompletedOver40YardsPer90 { get; set; }
        [Display(Name = "Passes Attempted >40 yds")]
        public int GkPassesAttemptedOver40Yards { get; set; }
        [Display(Name = "Passes Attempted >40 yds per 90")]
        public double GkPassesAttemptedOver40YardsPer90 { get; set; }
        [Display(Name = "Average Passes Completed >40 yds %")]
        public decimal GkAveragePassesCompletedOver40YardsPercentage { get; set; }
        [Display(Name = "Passes Completed >40 yds %")]
        public double GkPassesCompletedOver40YardsPercentage { get; set; }
        [Display(Name = "Throws Attempted")]
        public int GkThrowsAttempted { get; set; }
        [Display(Name = "Throws Attempted per 90")]
        public double GkThrowsAttemptedPer90 { get; set; }
        [Display(Name = "Average Passes Attempted >40 yds %")]
        public decimal GkAveragePassesAttemptedOver40YardsPercentage { get; set; }
        [Display(Name = "Passes Attempted >40 yds %")]
        public double GkPassesAttemptedOver40YardsPercentage { get; set; }
        [Display(Name = "Average Pass Length (yds)")]
        public decimal GkAverageYardsPassLength { get; set; }
        [Display(Name = "Goal Kicks Attempted")]
        public int GkGoalKicksAttempted { get; set; }
        [Display(Name = "Goal Kicks Attempted per 90")]
        public double GkGoalKicksAttemptedPer90 { get; set; }
        [Display(Name = "Avg Goal Kicks Launched %")]
        public decimal GkAverageGoalKicksLaunchedPercentage { get; set; }
        [Display(Name = "Goal Kicks Avg yds")]
        public decimal GkGoalKickAverageYards { get; set; }
        [Display(Name = "Opponent Crosses Attempted")]
        public int GkOpponentCrossesAttempted { get; set; }
        [Display(Name = "Avg Crosses Stopped %")]
        public decimal GkAverageCrossesStoppedPercentage { get; set; }
        [Display(Name = "Opponent Crosses Stopped %")]
        public double GkOpponentCrossesStoppedPercentage { get; set; }
        [Display(Name = "Defensive Actions Outside Box")]
        public int GkDefensiveActionsOutsidePenaltyArea { get; set; }
        [Display(Name = "Defensive Actions Outside Box per 90")]
        public double GkDefensiveActionsOutsidePenaltyAreaPer90 { get; set; }
        [Display(Name = "Avg Distance From Goal for Defensive Action")]
        public decimal GkAverageDistanceFromGoalForDefensiveActions { get; set; }
        [Display(Name = "Shot Creating Actions")]
        public int ShotCreatingActions { get; set; }
        [Display(Name = "Shot Creating Actions per 90")]
        public double ShotCreatingActionsPer90 { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Shot")]
        public int PassesCompletedLiveBallLeadingToShot { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Shot per 90")]
        public double PassesCompletedLiveBallLeadingToShotPer90 { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Shot")]
        public int PassesCompletedDeadBallLeadingToShot { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Shot per 90")]
        public double PassesCompletedDeadBallLeadingToShotPer90 { get; set; }
        [Display(Name = "Dribbles Leading to Shot")]
        public int DribblesLeadingToShot { get; set; }
        [Display(Name = "Dribbles Leading to Shot per 90")]
        public double DribblesLeadingToShotPer90 { get; set; }
        [Display(Name = "Shots Leading to Another Shot")]
        public int ShotsLeadingToAnotherShot { get; set; }
        [Display(Name = "Shots Leading to Another Shot per 90")]
        public double ShotsLeadingToAnotherShotPer90 { get; set; }
        [Display(Name = "Fouls Drawn Leading to Shot")]
        public int FoulsDrawnLeadingToShot { get; set; }
        [Display(Name = "Fouls Drawn Leading to Shot per 90")]
        public double FoulsDrawnLeadingToShotPer90 { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Goal")]
        public int PassesCompletedLiveBallLeadingToGoal { get; set; }
        [Display(Name = "Passes Completed (Live Ball) Leading to Goal per 90")]
        public double PassesCompletedLiveBallLeadingToGoalPer90 { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Goal")]
        public int PassesCompletedDeadBallLeadingToGoal { get; set; }
        [Display(Name = "Passes Completed (Dead Ball) Leading to Goal per 90")]
        public double PassesCompletedDeadBallLeadingToGoalPer90 { get; set; }
        [Display(Name = "Dribbles Leading to Goal")]
        public int DribblesLeadingToGoal { get; set; }
        [Display(Name = "Dribbles Leading to Goal per 90")]
        public double DribblesLeadingToGoalPer90 { get; set; }
        [Display(Name = "Shots Leading to Another Shot")]
        public int ShotsLeadingToAnotherGoal { get; set; }
        [Display(Name = "Shots Leading to Another Goal per 90")]
        public double ShotsLeadingToAnotherGoalPer90 { get; set; }
        [Display(Name = "Fouls Drawn Leading to Goal")]
        public int FoulsDrawnLeadingToGoal { get; set; }
        [Display(Name = "Fouls Drawn Leading to Goal per 90")]
        public double FoulsDrawnLeadingToGoalPer90 { get; set; }
        [Display(Name = "Actions Leading to Opponent Own Goal")]
        public int ActionsLeadingToOpponentOwnGoal { get; set; }
        [Display(Name = "Actions Leading to Opponent Own Goal per 90")]
        public double ActionsLeadingToOpponentOwnGoalPer90 { get; set; }
        [Display(Name = "Players Tackled")]
        public int PlayersTackled { get; set; }
        [Display(Name = "Players Tackled per 90")]
        public double PlayersTackledPer90 { get; set; }
        [Display(Name = "Tackles Won")]
        public int TacklesWon { get; set; }
        [Display(Name = "Tackles Won per 90")]
        public double TacklesWonPer90 { get; set; }
        [Display(Name = "Tackles Defensive Third")]
        public int TacklesDefensiveThird { get; set; }
        [Display(Name = "Tackles Middle Third")]
        public int TacklesMiddleThird { get; set; }
        [Display(Name = "Tackles Attacking Third")]
        public int TacklesAttackingThird { get; set; }
        [Display(Name = "Dribblers Tackled")]
        public int DribblersTackled { get; set; }
        [Display(Name = "Dribbles Contested")]
        public int DribblesContested { get; set; }
        [Display(Name = "Avg Dribblers Tackled %")]
        public decimal AverageDribblersTackledPercentage { get; set; }
        [Display(Name = "Dribblers Tackled %")]
        public double DribblersTackledPercentage { get; set; }
        [Display(Name = "Times Dribbled Past")]
        public int TimesDribbledPast { get; set; }
        [Display(Name = "Time Dribbled Past per 90")]
        public double TimesDribbledPastPer90 { get; set; }
        public int Pressures { get; set; }
        [Display(Name = "Pressures per 90")]
        public double PressuresPer90 { get; set; }
        [Display(Name = "Successful Pressures")]
        public int SuccessfulPressures { get; set; }
        [Display(Name = "Successful Pressures per 90")]
        public double SuccessfulPressuresPer90 { get; set; }
        [Display(Name = "Avg Successful Pressures %")]
        public decimal AverageSuccessfulPressuresPercentage { get; set; }
        [Display(Name = "Successful Pressures %")]
        public double SuccessfulPressuresPercentage { get; set; }
        [Display(Name = "Pressures Defensive Third")]
        public int PressuresDefensiveThird { get; set; }
        [Display(Name = "Pressures Middle Third")]
        public int PressuresMiddleThird { get; set; }
        [Display(Name = "Pressures Attacking Third")]
        public int PressuresAttackingThird { get; set; }
        public int Blocks { get; set; }
        [Display(Name = "Blocks per 90")]
        public double BlocksPer90 { get; set; }
        [Display(Name = "Shots Blocked")]
        public int ShotsBlocked { get; set; }
        [Display(Name = "Shots on Target Blocked")]
        public int ShotsOnTargetBlocked { get; set; }
        [Display(Name = "Passes Blocked")]
        public int PassesBlocked { get; set; }
        public int Interceptions { get; set; }
        [Display(Name = "Interceptions per 90")]
        public double InterceptionsPer90 { get; set; }
        [Display(Name = "Players Tackled + Interceptions")]
        public int PlayersTackledAndInterceptions { get; set; }
        [Display(Name = "Players Tackled + Interceptions per 90")]
        public double PlayersTackledAndInterceptionsPer90 { get; set; }
        public int Clearances { get; set; }
        [Display(Name = "Clearances per 90")]
        public double ClearancesPer90 { get; set; }
        [Display(Name = "Errors Leading to Shot")]
        public int ErrorsLeadingToShot { get; set; }
        [Display(Name = "Errors Leading to Shot per 90")]
        public double ErrorsLeadingToShotPer90 { get; set; }
    }
}
