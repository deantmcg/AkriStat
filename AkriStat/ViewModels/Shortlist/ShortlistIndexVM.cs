using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Shortlist
{
    public class ShortlistIndexVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastUpdatedDate { get; set; }
        public int PlayerCount { get; set; }
    }
}
