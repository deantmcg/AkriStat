using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Scrape
{
    public class BatchDetailsVM
    {
        public int ID { get; set; }

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public string Season { get; set; }

        public List<BatchJobIndexVM> Jobs { get; set; }
    }
}
