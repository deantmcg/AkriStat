using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Account
{
    public class AccountDetailsVM
    {
        [Display(Name = "First Name"), Required, MinLength(2), MaxLength(150)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(150)]
        public string Surname { get; set; }

        public string FullName { get { return $"{FirstName} {Surname}"; } }

        [Display(Name = "Favourite Team"), Required]
        public int FavouriteTeamId { get; set; }

        public List<SelectListItem> TeamsSelectList { get; set; }
    }
}
