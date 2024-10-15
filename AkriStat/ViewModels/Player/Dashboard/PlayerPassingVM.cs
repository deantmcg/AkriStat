using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Dashboard
{
    public class PlayerPassingVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double PassesAttemptedPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double PassesCompletedPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double ProgressivePassesPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double AssistsPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double XgAssistedPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double KeyPassesPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double ChancesCreatedPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double PassesReceivedPercentage { get; set; }
    }
}
