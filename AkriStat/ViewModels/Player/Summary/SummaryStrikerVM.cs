using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.ViewModels.Player.Summary
{
    public class SummaryStrikerVM
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? ChancesCreatedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? ChancesCreatedPer90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? TouchesAttackingPenaltyAreaPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? TouchesAttackingPenaltyAreaPer90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? ShotsOnTargetPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? ShotsOnTargetPer90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? SuccessfulDribblesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? SuccessfulDribblesPer90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? SuccessfulDribblesPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? SuccessfulDribblesPercentagePercentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? NonPenaltyXgperShot { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? NonPenaltyXgperShotPercentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? NonPenaltyXgper90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? NonPenaltyXgper90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double? XgassistedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? XgassistedPer90Percentile { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}")]
        public int? Goals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double? GoalsPercentile { get; set; }
    }
}
