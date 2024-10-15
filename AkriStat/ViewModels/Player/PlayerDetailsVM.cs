using AkriStat.Helpers;
using AkriStat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Player
{
    public class PlayerDetailsVM
    {
        public int ID { get; set; }

        public string FacePictureUrl { get; set; }

        public string Name { get; set; }

        [Display(Name="Full Name")]
        public string FullName { get; set; }

        public string Position { get; set; }
        public string PositionDisplay { get; set; }
        public string PositionColourCode { get; set; }

        public string Club { get; set; }

        public int ClubID { get; set; }

        public string Footed { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? HeightCm { get; set; }
        public string HeightFt 
        {
            get
            {
                if (HeightCm != null)
                {
                    string ft = (Convert.ToDouble(HeightCm.Value) / 30.48).ToString("#.#");
                    var split = ft.Split(".");
                    if (split.Length == 1)
                        return $"{split[0]}ft";
                    return $"{split[0]}ft {split[1]}\"";
                }
                else
                    return null;
            }
        }

        public int? WeightKg { get; set; }
        public int? WeightLbs 
        { 
            get
            {
                if (WeightKg != null)
                {
                    return Convert.ToInt32(WeightKg.Value * 2.2046226218);
                }
                else
                    return null;
            }
        }

        [Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }
        public string Age 
        { 
            get
            {
                if (DateOfBirth != null)
                {
                    DateTime dtNow = DateTime.Today;
                    int years = new DateTime(dtNow.Subtract(DateOfBirth.Value).Ticks).Year - 1;
                    DateTime dobDateNow = DateOfBirth.Value.AddYears(years);
                    int _Months = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        if (dobDateNow.AddMonths(i) == dtNow)
                        {
                            _Months = i;
                            break;
                        }
                        else if (dobDateNow.AddMonths(i) >= dtNow)
                        {
                            _Months = i - 1;
                            break;
                        }
                    }
                    int Days = dtNow.Subtract(dobDateNow).Days;

                    return $"{years} ({Days}d)";
                }
                else
                    return null;
            }
        }

        public string Nationality { get; set; }

        public string NationalityFlag { get; set; }


        public string SecondNationality { get; set; }

        public string SecondNationalityFlag { get; set; }

        public string PlaceOfBirth { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? Value { get; set; }

        public string ValueString 
        { 
            get
            {
                var formatter = new Formatter();
                return formatter.GetCurrencyString(Value.Value);
            }
        }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal? WeeklyWage { get; set; }

        public string WeeklyWageString
        {
            get
            {
                var formatter = new Formatter();
                return formatter.GetCurrencyString(WeeklyWage.Value);
            }
        }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ContractExpiry { get; set; }

        public string TwitterUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string InstagramUrl { get; set; }

        public bool IsShortlisted { get; set; }

        public List<ShortlistedPlayerVM> Shortlists { get; set; }

        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
