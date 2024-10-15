using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Shortlist
{
    public class ShortlistCreateVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required")]
        [MaxLength(150, ErrorMessage = "Maximum 150 Characters")]
        public string Name { get; set; }
    }
}
