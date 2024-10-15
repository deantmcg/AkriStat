using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.ViewModels.Player.Summary
{
    public class SummaryAttackingMidAndWingerVM
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Season { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double ChancesCreatedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double ChancesCreatedPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double XgassistedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double XgassistedPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Xgper90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double Xgper90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double CrossesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double CrossesPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulDribblesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulDribblesPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double SuccessfulDribblesPercentage { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double SuccessfulDribblesPercentagePercentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesIntoFinalThirdPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesIntoFinalThirdPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double YardsProgressiveCarriesPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double YardsProgressiveCarriesPer90Percentile { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double PassesCompletedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0}")]
        public double PassesCompletedPer90Percentile { get; set; }
    }
}
