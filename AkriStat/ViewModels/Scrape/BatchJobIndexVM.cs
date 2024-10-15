using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkriStat.ViewModels.Scrape
{
    public class BatchJobIndexVM
    {
        public int ID { get; set; }

        public string FbRefID { get; set; }

        public int? PlayerID { get; set; }

        public string PlayerName { get; set; }

        [Display(Name = "Status")]
        public bool? Successful { get; set; }

        public int? ImportID { get; set; }

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Message"), DisplayFormat(NullDisplayText = "-")]
        public string ErrorMessage { get; set; }
    }
}
