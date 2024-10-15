using AkriStat.ViewModels.Search;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AkriStat.ViewModels.Compare
{
    public class ComparePlayerVM
    {
        public List<SelectListItem> PlayerSelectList { get; set; } = new List<SelectListItem>();
        public List<ChosenPlayerSeason> ChosenPlayerSeasons { get; set; } = new List<ChosenPlayerSeason>();
        public List<AdvancedSearchResultVM> Results { get; set; } = new List<AdvancedSearchResultVM>();
        
    }

    public class ChosenPlayerSeason
    {
        public int? ID { get; set; }
        public string Season { get; set; }
    }
}
