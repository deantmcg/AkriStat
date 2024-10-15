using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Administrator
{
    public class UserIndexVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        [DisplayFormat(NullDisplayText = "Freelance")]
        public string Team { get; set; }
    }
}
