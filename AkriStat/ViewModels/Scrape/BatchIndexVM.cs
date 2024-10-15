using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Scrape
{
    public class BatchIndexVM
    {
        public int ID { get; set; }

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Job Lines")]
        public int ScrapeCount { get; set; }
    }
}
