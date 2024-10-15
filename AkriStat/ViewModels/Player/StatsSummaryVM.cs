namespace AkriStat.ViewModels.Player
{
    public class StatsSummaryVM
    {
        public int PlayerId { get; set; }

        // FULL BACK STATS
        public double XgassistedPer90 { get; set; }
        public double XgassistedPer90Percentile { get; set; }
        public double PassesIntoFinalThirdPer90 { get; set; }
        public double PassesIntoFinalThirdPer90Percentile { get; set; }
        public double YardsProgressiveControlledWithFeetPer90 { get; set; }
        public double YardsProgressedPer90Percentile { get; set; }
        public double PassesCompletedPercentage { get; set; }
        public double PassesCompletedPercentagePercentile { get; set; }
        public double SuccessfulDribblesPer90 { get; set; }
        public double SuccessfulDribblesPer90Percentile { get; set; }
        public double SuccessfulDribblesPercentage { get; set; }
        public double SuccessfulDribblesPercentagePercentile { get; set; }
        public double SuccessfulPressuresPer90 { get; set; }
        public double SuccessfulPressuresPer90Percentile { get; set; }
        public double InterceptionsPer90 { get; set; }
        public double InterceptionsPer90Percentile { get; set; }
        public double TacklesWonPer90 { get; set; }
        public double TacklesWonPer90Percentile { get; set; }
        public double DribblersTackledPercentage { get; set; }
        public double DribblersTackledPercentagePercentile { get; set; }
        public double AerialDualsWonPercentage { get; set; }
        public double AerialDualsWonPercentagePercentile { get; set; }
    }
}
