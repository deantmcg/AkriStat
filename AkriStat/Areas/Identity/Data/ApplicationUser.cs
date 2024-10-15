using Microsoft.AspNetCore.Identity;

namespace AkriStat.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
    }
}
