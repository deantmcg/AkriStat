using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Scrape
{
    public class ScrapeDetailsVM
    {
        [Required]
        public string Season { get; set; } = Constants.SiteProperties.CurrentSeason;

        [Display(Name = "New Players (FbRef IDs)")]
        public string FbRefIds { get; set; }

        [Display(Name = "Existing Players")]
        public int[] PlayerIds { get; set; }

        public List<SelectListItem> PlayerSelectList { get; set; }
        public List<SelectListItem> SeasonSelectList { get; set; }
        public List<SelectListItem> TeamSelectList { get; set; }

        public List<string> FailedScrapes { get; set; } = new List<string>();
    }
}
