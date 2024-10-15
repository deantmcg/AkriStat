using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AkriStat.Helpers
{
    public class ImportHelper
    {
        public List<string> DataHeaders { get; set; }
        public List<List<string>> CsvLines { get; set; }
        public List<ScrapeColumnData> ColumnData { get; set; } = new List<ScrapeColumnData>();

        public ImportHelper(byte[] csvFileBytes)
        {
            try
            {
                LoadCsv(csvFileBytes);
                LoadColumnData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadCsv(byte[] csvFileBytes)
        {
            using (var stream = new MemoryStream(csvFileBytes))
            {
                using (var reader = new StreamReader(stream, true))
                {
                    var csvStr = reader.ReadToEnd();
                    CsvLines = csvStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                        .Select(x => x.Split(",").ToList())
                        .Where(x => !x.All(y => String.IsNullOrEmpty(y)))
                        .ToList();

                    DataHeaders = CsvLines[0];
                    CsvLines.RemoveAt(0);
                }
            }
        }

        private void LoadColumnData()
        {
            foreach (var item in dataNames)
            {
                ColumnData.Add(new ScrapeColumnData() 
                { 
                    Name = item[0], 
                    DbColumnName = item[1],
                    Index = DataHeaders.IndexOf(item[0])
                });
            }
        }

        public string GetValue(int lineIndex, string dbColumnName)
        {
            return CsvLines[lineIndex][ColumnData.FirstOrDefault(x => x.DbColumnName.ToLower().Equals(dbColumnName.ToLower())).Index];
        }

        public string GetValueByHeaderName(int lineIndex, string headerName)
        {
            return CsvLines[lineIndex][ColumnData.FirstOrDefault(x => x.Name.ToLower().Equals(headerName.ToLower())).Index];
        }

        private readonly string[][] dataNames =
            {
                new string[] { "venue", "" },
                new string[] { "dayofweek", "" },
                new string[] { "comp", "" },
                new string[] { "round", "" },
                new string[] { "result", "" },
                new string[] { "squad", "" },
                new string[] { "opponent", "" },
                new string[] { "game_started", "Started" },
                new string[] { "position", "PositionPlayed" },
                new string[] { "minutes", "MinutesPlayed" },
                new string[] { "passes_completed", "PassesCompleted" },
                new string[] { "passes", "PassesAttempted" },
                new string[] { "passes_pct", "PassesCompletedPercentage" },
                new string[] { "passes_total_distance", "YardsPassed" },
                new string[] { "passes_progressive_distance", "YardsPassedProgressive" },
                new string[] { "passes_completed_short", "ShortPassesCompleted" },
                new string[] { "passes_short", "ShortPassesAttempted" },
                new string[] { "passes_pct_short", "ShortPassesCompletedPercentage" },
                new string[] { "passes_completed_medium", "MediumPassesCompleted" },
                new string[] { "passes_medium", "MediumPassesAttempted" },
                new string[] { "passes_pct_medium", "MediumPassesCompletedPercentage" },
                new string[] { "passes_completed_long", "LongPassesCompleted" },
                new string[] { "passes_long", "LongPassesAttempted" },
                new string[] { "passes_pct_long", "LongPassesCompletedPercentage" },
                new string[] { "assists", "Assists" },
                new string[] { "xa", "XgAssisted" },
                new string[] { "assisted_shots", "KeyPasses" },
                new string[] { "passes_into_final_third", "PassesIntoFinalThird" },
                new string[] { "passes_into_penalty_area", "PassesIntoPenaltyArea" },
                new string[] { "crosses_into_penalty_area", "CrossesIntoPenaltyArea" },
                new string[] { "progressive_passes", "ProgressivePasses" },
                new string[] { "passes_live", "PassesAttemptedLiveBall" },
                new string[] { "passes_dead", "PassesAttemptedDeadBall" },
                new string[] { "passes_free_kicks", "PassesAttemptedFreeKick" },
                new string[] { "through_balls", "PassesCompletedThroughBall" },
                new string[] { "passes_pressure", "PassesCompletedUnderPressure" },
                new string[] { "passes_switches", "Switches" },
                new string[] { "crosses", "Crosses" },
                new string[] { "corner_kicks", "CornerKicks" },
                new string[] { "corner_kicks_in", "CornerKicksInswinging" },
                new string[] { "corner_kicks_out", "CornerKicksOutswinging" },
                new string[] { "corner_kicks_straight", "CornerKicksStraight" },
                new string[] { "passes_ground", "PassesGround" },
                new string[] { "passes_low", "PassesLow" },
                new string[] { "passes_high", "PassesHigh" },
                new string[] { "passes_left_foot", "PassesLeftFoot" },
                new string[] { "passes_right_foot", "PassesRightFoot" },
                new string[] { "passes_head", "PassesHeaded" },
                new string[] { "throw_ins", "PassesThrowIn" },
                new string[] { "passes_other_body", "PassesOther" },
                new string[] { "passes_offsides", "PassesOffside" },
                new string[] { "passes_oob", "PassesOutOfBounds" },
                new string[] { "passes_intercepted", "PassesAttemptedIntercepted" },
                new string[] { "passes_blocked", "PassesAttemptedBlocked" },
                new string[] { "sca", "ShotCreatingActions" },
                new string[] { "sca_passes_live", "PassesCompletedLiveBallLeadingToShot" },
                new string[] { "sca_passes_dead", "PassesCompletedDeadBallLeadingToShot" },
                new string[] { "sca_dribbles", "DribblesLeadingToShot" },
                new string[] { "sca_shots", "ShotsLeadingToAnotherShot" },
                new string[] { "sca_fouled", "FoulsDrawnLeadingToShot" },
                //new string[] { "sca_defense" },
                new string[] { "gca", "GoalCreatingActions" },
                new string[] { "gca_passes_live", "PassesCompletedLiveBallLeadingToGoal" },
                new string[] { "gca_passes_dead", "PassesCompletedDeadBallLeadingToGoal" },
                new string[] { "gca_dribbles", "DribblesLeadingToGoal" },
                new string[] { "gca_shots", "ShotsLeadingToAnotherGoal" },
                new string[] { "gca_fouled", "FoulsDrawnLeadingToGoal" },
                //new string[] { "gca_defense" },
                new string[] { "gca_og_for", "ActionsLeadingToOpponentOwnGoal" },
                new string[] { "tackles", "PlayersTackled" },
                new string[] { "tackles_won", "TacklesWon" },
                new string[] { "tackles_def_3rd", "TacklesDefensiveThird" },
                new string[] { "tackles_mid_3rd", "TacklesMiddleThird" },
                new string[] { "tackles_att_3rd", "TacklesAttackingThird" },
                new string[] { "dribble_tackles", "DribblersTackled" },
                new string[] { "dribbles_vs", "DribblesContested" },
                new string[] { "dribble_tackles_pct", "DribblersTackledPercentage" },
                new string[] { "dribbled_past", "TimesDribbledPast" },
                new string[] { "pressures", "Pressures" },
                new string[] { "pressure_regains", "SuccessfulPressures" },
                new string[] { "pressure_regain_pct", "SuccessfulPressuresPercentage" },
                new string[] { "pressures_def_3rd", "PressuresDefensiveThird" },
                new string[] { "pressures_mid_3rd", "PressuresMiddleThird" },
                new string[] { "pressures_att_3rd", "PressuresAttackingThird" },
                new string[] { "blocks", "Blocks" },
                new string[] { "blocked_shots", "ShotsBlocked" },
                new string[] { "blocked_shots_saves", "ShotsOnTargetBlocked" },
                new string[] { "blocked_passes", "PassesBlocked" },
                new string[] { "interceptions", "Interceptions" },
                new string[] { "tackles_interceptions", "PlayersTackledAndInterceptions" },
                new string[] { "clearances", "Clearances" },
                new string[] { "errors", "ErrorsLeadingToShot" },
                new string[] { "touches", "Touches" },
                new string[] { "touches_def_pen_area", "TouchesDefensivePenaltyArea" },
                new string[] { "touches_def_3rd", "TouchesDefensiveThird" },
                new string[] { "touches_mid_3rd", "TouchesMiddleThird" },
                new string[] { "touches_att_3rd", "TouchesAttackingThird" },
                new string[] { "touches_att_pen_area", "TouchesAttackingPenaltyArea" },
                new string[] { "touches_live_ball", "LiveBallTouches" },
                new string[] { "dribbles_completed", "SuccessfulDribbles" },
                new string[] { "dribbles", "DribblesAttempted" },
                new string[] { "dribbles_completed_pct", "SuccessfulDribblesPercentage" },
                new string[] { "players_dribbled_past", "PlayersDribbledPast" },
                new string[] { "nutmegs", "Nutmegs" },
                new string[] { "carries", "ControlledBallWithFeet" },
                new string[] { "carry_distance", "YardsControlledWithFeet" },
                new string[] { "carry_progressive_distance", "YardsProgressiveControlledWithFeet" },
                //new string[] { "progressive_carries" },
                //new string[] { "carries_into_final_third" },
                //new string[] { "carries_into_penalty_area" },
                new string[] { "miscontrols", "Miscontrols" },
                new string[] { "dispossessed", "Dispossessed" },
                new string[] { "pass_targets", "WasTargetOfPass" },
                new string[] { "passes_received", "PassesReceived" },
                new string[] { "passes_received_pct", "PassesReceivedPercentage" },
                //new string[] { "progressive_passes_received" },
                new string[] { "cards_yellow", "YellowCard" },
                new string[] { "cards_red", "RedCard" },
                new string[] { "cards_yellow_red", "TwoYellowCards" },
                new string[] { "fouls", "Fouls" },
                new string[] { "fouled", "FoulsDrawn" },
                new string[] { "offsides", "Offsides" },
                new string[] { "interceptions", "Interceptions" },
                new string[] { "pens_won", "PenaltyKicksWon" },
                new string[] { "pens_conceded", "PenaltyKicksConceded" },
                new string[] { "own_goals", "OwnGoals" },
                new string[] { "ball_recoveries", "LooseBallsRecovered" },
                new string[] { "aerials_won", "AerialDualsWon" },
                new string[] { "aerials_lost", "AerialDualsLost" },
                new string[] { "aerials_won_pct", "AerialDualsWonPercentage" },
                new string[] { "goals", "Goals" },
                new string[] { "shots_total", "Shots" },
                new string[] { "shots_on_target", "ShotsOnTarget" },
                new string[] { "shots_on_target_pct", "ShotsOnTargetPercentage" },
                //new string[] { "shots_total_per90" },
                //new string[] { "shots_on_target_per90" },
                new string[] { "goals_per_shot", "GoalsPerShot" },
                new string[] { "goals_per_shot_on_target", "GoalsPerShotOnTarget" },
                //new string[] { "average_shot_distance", },
                //new string[] { "shots_free_kicks" },
                new string[] { "pens_made", "PenaltyKicksMade" },
                new string[] { "pens_att", "PenaltyKicksAttempted" },
                new string[] { "xg", "Xg" },
                new string[] { "npxg", "NonPenaltyXg" },
                new string[] { "npxg_per_shot", "NonPenaltyXgPerShot" },
                new string[] { "xg_net", "NonPenaltyGoalsMinusXG" },
                //new string[] { "npxg_net" },
                new string[] { "shots_on_target_against", "GkShotsOnTargetFaced" },
                new string[] { "goals_against_gk", "GkGoalsConceded" },
                new string[] { "saves", "GkSaves" },
                new string[] { "save_pct", "GkSavesPercentage" },
                new string[] { "clean_sheets", "GkCleanSheet" },
                new string[] { "psxg_gk", "GkPostShotXg" },
                new string[] { "pens_att_gk", "GkPenaltiesFaced" },
                new string[] { "pens_allowed", "GkPenaltiesConceded" },
                new string[] { "pens_saved", "GkPenaltiesSaved" },
                new string[] { "pens_missed_gk", "GkPenaltiesFacedMissed" },
                new string[] { "passes_completed_launched_gk", "GkPassesCompletedOver40Yards" },
                new string[] { "passes_launched_gk", "GkPassesAttemptedOver40Yards" },
                new string[] { "passes_pct_launched_gk", "GkPassesCompletedOver40YardsPercentage" },
                new string[] { "passes_gk", "GkPassesAttempted" },
                new string[] { "passes_throws_gk", "GkThrowsAttempted" },
                new string[] { "pct_passes_launched_gk", "GkPassesOver40YardsPercentage" },
                new string[] { "passes_length_avg_gk", "GkAverageYardsPassLength" },
                new string[] { "goal_kicks", "GkGoalKicksAttempted" },
                new string[] { "pct_goal_kicks_launched", "GkGoalKicksLaunchedPercentage" },
                new string[] { "goal_kick_length_avg", "GkGoalKickAverageYards" },
                new string[] { "crosses_gk", "GkOpponentCrossesAttempted" },
                new string[] { "crosses_stopped_gk", "GkCrossesStopped" },
                new string[] { "crosses_stopped_pct_gk", "GkCrossesStoppedPercentage" },
                new string[] { "def_actions_outside_pen_area_gk", "GkDefensiveActionsOutsidePenaltyArea" },
                new string[] { "avg_distance_def_actions_gk", "GkAverageDistanceFromGoalForDefensiveActions" }
        };
    }
}
