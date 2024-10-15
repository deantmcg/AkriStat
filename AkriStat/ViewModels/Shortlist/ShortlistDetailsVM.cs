using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Shortlist
{
    public class ShortlistDetailsVM
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required"), MaxLength(150, ErrorMessage = "Maximum 150 Characters")]
        public string Name { get; set; }
        public string Heading { get; set; }

        [Display(Name = "Created"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Last Updated"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime LastUpdatedDate { get; set; }
        public bool IsDefault { get; set; }
    }
}
