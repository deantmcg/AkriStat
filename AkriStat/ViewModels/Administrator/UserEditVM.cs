using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Administrator
{
    public class UserEditVM
    {
        public string Id { get; set; }
        [Required, Display(Name = "First Name"), MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string Surname { get; set; }
        public string FullName 
        { 
            get
            {
                return $"{FirstName} {Surname}";
            }
        }
        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }
        public string NormalizedEmail
        {
            get
            {
                return Email.ToUpper();
            }
        }
        public string Username
        {
            get
            {
                return Email;
            }
        }
        public string NormalizedUsername
        {
            get
            {
                return Email.ToUpper();
            }
        }
        [Required, Display(Name = "Role")]
        public string RoleId { get; set; }
        [Display(Name = "Team")]
        public int? TeamId { get; set; }
        public List<SelectListItem> RoleSelectList { get; set; }
        public List<SelectListItem> TeamsSelectList { get; set; }
    }
}
