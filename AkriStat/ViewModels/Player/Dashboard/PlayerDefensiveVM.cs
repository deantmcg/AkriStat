using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Dashboard
{
    public class PlayerDefensiveVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double TacklesWonPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double DribblersTackledPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double SuccessfulPressuresPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double SuccessfulPressuresPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double BlocksPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double InterceptionsPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double ClearancesPer90 { get; set; }
    }
}
