using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player.Dashboard
{
    public class PlayerPossessionVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double TouchesPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double SuccessfulDribblesPercentage { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double PlayersDribbledPastPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double CarriesPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double YardsProgressiveCarriesPer90 { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double PassesReceivedPercentage { get; set; }
    }
}
