using AkriStat.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Team
{
    public class TeamEditVM
    {
        public int ID { get; set; }
        [Required]
        public string FbRefID { get; set; }
        [Required]
        public string Name { get; set; }
        public string NormalizedName
        {
            get
            {
                return Normalizer.NormalizeString(Name);
            }
        }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string NormalizedFullName
        {
            get
            {
                return Normalizer.NormalizeString(FullName);
            }
        }
        [Display(Name = "Year Founded")]
        public int? YearFounded { get; set; }
        [Display(Name = "Stadium Name")]
        public string StadiumName { get; set; }
        public string Address { get; set; }
        [Required, Display(Name = "Nation")]
        public int NationID { get; set; }
        [Required, Display(Name = "Current League")]
        public int CurrentLeagueID { get; set; }
        [Required, Display(Name = "Team Type")]
        public int TeamTypeID { get; set; }
        [Required, Display(Name = "Main Colour")]
        [RegularExpression("^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$", ErrorMessage = "Six digit hex code required.")]
        public string ColourCode1 { get; set; }
        [Required, Display(Name = "Secondary Colour")]
        public string ColourCode2 { get; set; }
        [Display(Name = "Third Colour")]
        public string ColourCode3 { get; set; }

        public List<SelectListItem> NationSelectList { get; set; }
        public List<SelectListItem> LeagueSelectList { get; set; }
        public List<SelectListItem> TeamTypeSelectList { get; set; }
    }
}
