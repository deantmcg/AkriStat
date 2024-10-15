using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Account
{
    public class StaffDetailsVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string RoleId { get; set; }
        public int TeamId { get; set; }
    }
}
