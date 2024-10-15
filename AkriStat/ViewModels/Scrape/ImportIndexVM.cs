using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Scrape
{
    public class ImportIndexVM
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }

        [Display(Name = "Player")]
        public string PlayerName { get; set; }

        public string Season { get; set; }

        [Display(Name = "Date Scraped"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateScraped { get; set; }

        public bool Executed { get; set; }

        [Display(Name = "Date Imported"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "")]
        public DateTime? DateExecuted { get; set; }

        public bool? Success { get; set; }
    }
}
