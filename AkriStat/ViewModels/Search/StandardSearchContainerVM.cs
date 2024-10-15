using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Search
{
    public class StandardSearchContainerVM
    {
        [Required(ErrorMessage = "A search query is required")]
        public string Query { get; set; }
        public List<StandardSearchResultVM> Players { get; set; }
        public List<StandardSearchResultVM> Teams { get; set; }
    }
}
