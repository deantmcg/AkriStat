using System;

namespace AkriStat.ViewModels.Player.Summary
{
    public class BarsVM
    {
        //Aerial Duals
        public int AerialDuals { get { return AerialDualsWon + AerialDualsLost; } }
        public int AerialDualsWon { get; set; }
        public int AerialDualsLost { get; set; }
        public int AerialDualsWonPercentage { get; set; }
        //Dribbles
        public int DribblesAttempted { get; set; }
        public int SuccessfulDribbles { get; set; }
        public int SuccessfulDribblesPercentage { get; set; }
        //Blocks
        public int Blocks { get; set; }
        public int ShotsBlocked { get; set; }
        public int ShotsOnTargetBlocked { get; set; }
        public double ShotsOnTargetBlockedPercentage { get { return GetPercentage(ShotsOnTargetBlocked, Blocks); } }
        public int ShotsOffTargetBlocked { get { return ShotsBlocked - ShotsOnTargetBlocked; } }
        public double ShotsOffTargetBlockedPercentage { get { return GetPercentage(ShotsOffTargetBlocked, Blocks); } }
        public int PassesBlocked { get; set; }
        public double PassesBlockedPercentage { get { return GetPercentage(PassesBlocked, Blocks); } }
        //Tackles
        public int PlayersTackled { get; set; }
        public int TacklesWon { get; set; }
        public int TacklesWonPercentage { get; set; }
        public int Interceptions { get; set; }
        public int PlayersTackledAndInterceptions { get; set; }
        //Pressures
        public int Pressures { get; set; }
        public int SuccessfulPressures { get; set; }
        public double SuccessfulPressuresPercentage { get; set; }
        public int PressuresDefensiveThird { get; set; }
        public int PressuresMiddleThird { get; set; }
        public int PressuresAttackingThird { get; set; }
        //Pass Completion
        public int PassesAttempted { get; set; }
        public int PassesCompleted { get; set; }
        public int PassesCompletedPercentage { get; set; }
        //Pass Length
        public int ShortPassesCompleted { get; set; }
        public int MediumPassesCompleted { get; set; }
        public int LongPassesCompleted { get; set; }
        //Pass Height
        public int PassesGround { get; set; }
        public int PassesLow { get; set; }
        public int PassesHigh { get; set; }
        //Pass Result
        public int KeyPasses { get; set; }
        public int PassesAttemptedBlocked { get; set; }
        public int PassesAttemptedIntercepted { get; set; }
        public int PassesAttemptedOutOfBounds { get; set; }
        //Pass Final Third
        public int PassesIntoFinalThird { get; set; }
        public double PassesIntoFinalThirdPercentage { get { return GetPercentage(PassesIntoFinalThird, PassesAttempted); } }
        //Pass Progressive
        public int ProgressivePasses { get; set; }
        public double ProgressivePassesPercentage { get { return GetPercentage(ProgressivePasses, PassesAttempted); } }
        //Pass Long
        public int LongPassesAttempted { get; set; }
        public double LongPassesCompletedPercentage { get; set; }
        // Dribbles Contested
        public int DribblesContested { get; set; }
        public int DribblersTackled { get; set; }
        public double DribblersTackledPercentage { get; set; }
        // Shot Creating Actions
        public int PassesCompletedLiveBallLeadingToShot { get; set; }
        public int PassesCompletedDeadBallLeadingToShot { get; set; }
        public int DribblesLeadingToShot { get; set; }
        public int ShotsLeadingToAnotherShot { get; set; }
        public int FoulsDrawnLeadingToShot { get; set; }
        // Goal Creating Actions
        public int PassesCompletedLiveBallLeadingToGoal { get; set; }
        public int PassesCompletedDeadBallLeadingToGoal { get; set; }
        public int DribblesLeadingToGoal { get; set; }
        public int ShotsLeadingToAnotherGoal { get; set; }
        public int FoulsDrawnLeadingToGoal { get; set; }
        // Shots on Target
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int ShotsOnTargetPercentage { get; set; }
        // Passes Received
        public int WasTargetOfPass { get; set; }
        public int PassesReceived { get; set; }
        public double PassesReceivedPercentage { get; set; }


        // KEEPER

        // Clean Sheets
        public int GkCleanSheets { get; set; }
        public int GamesPlayed { get; set; }
        public double GkCleanSheetsPercentage { get { return GetPercentage(GkCleanSheets, GamesPlayed); } }
        // Penalties Faced
        public int GkPenaltiesFaced { get; set; }
        public int GkPenaltiesSaved { get; set; }
        public double GkPenaltiesSavedPercentage { get { return GetPercentage(GkPenaltiesSaved, GkPenaltiesFaced); } }
        // Passes over 40 Yards
        public int GkPassesAttemptedOver40Yards { get; set; }
        public int GkPassesCompletedOver40Yards { get; set; }
        public double GkPassesCompletedOver40YardsPercentage { get; set; }
        public double GkPassesAttemptedOver40YardsPercentage { get; set; }
        // Crosses Stopped
        public int GkOpponentCrossesAttempted { get; set; }
        public int GkCrossesStopped { get; set; }
        public double GkOpponentCrossesStoppedPercentage { get; set; }


        public double GetPercentage(int dividend, int divisor)
        {
            return Convert.ToDouble(dividend) / divisor * 100;
        }
    }
}
