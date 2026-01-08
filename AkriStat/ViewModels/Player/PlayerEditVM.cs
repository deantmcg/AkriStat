using AkriStat.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player
{
    public class PlayerEditVM
    {
        public int ID { get; set; }

        [MaxLength(300), Display(Name = "Face Picture URL")]
        public string FacePictureUrl { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }
        public string NormalizedName 
        { 
            get 
            {
                return Normalizer.NormalizeString(Name);
            } 
        }

        [MaxLength(300), Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string NormalizedFullName 
        { 
            get 
            { 
                return Normalizer.NormalizeString(FullName); 
            } 
        }

        [Required, Display(Name = "Position")]
        public int PositionID { get; set; }

        [Required]
        public string Footed { get; set; }

        [Display(Name = "Height (cm)")]
        public decimal? Height { get; set; }

        [Display(Name = "Weight (kg)")]
        public int? Weight { get; set; }

        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required, Display(Name = "Nationality")]
        public int NationalityId { get; set; }

        [Display(Name = "Second Nationality")]
        public int? SecondNationalityId { get; set; }

        [Display(Name = "Place of Birth"), MaxLength(80)]
        public string PlaceOfBirth { get; set; }

        public decimal? Value { get; set; }

        [Display(Name = "Weekly Wage")]
        public decimal? WeeklyWage { get; set; }

        [Display(Name = "Contract Expiry"), DataType(DataType.Date)]
        public DateTime? ContractExpiry { get; set; }

        [Display(Name = "Twitter URL"), MaxLength(300)]
        public string TwitterUrl { get; set; }

        [Display(Name = "Facebook URL"), MaxLength(300)]
        public string FacebookUrl { get; set; }

        [Display(Name = "Instagram URL"), MaxLength(300)]
        public string InstagramUrl { get; set; }

        public List<SelectListItem> PositionSelectList { get; set; }
        public List<SelectListItem> NationalitySelectList { get; set; }
    }
}
