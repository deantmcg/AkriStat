using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Dashboard
{
    public class PlayerAttackingVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Goals { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? GoalsPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public decimal? NonPenaltyXG { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? NonPenaltyXGPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? GoalsPerShot { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? ShotsPer90 { get; set; }
        public int? ChancesCreated { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? ChancesCreatedPer90 { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double? TouchesAttackingPenaltyAreaPer90 { get; set; }
    }
}
