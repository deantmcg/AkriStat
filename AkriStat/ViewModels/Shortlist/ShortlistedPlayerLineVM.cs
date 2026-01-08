using AkriStat.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace AkriStat.ViewModels.Shortlist
{
    public class ShortlistedPlayerLineVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Footed { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Value { get; set; }
        public string ValueString
        { 
            get
            {
                return Formatter.GetCurrencyString(Value);
            }
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ContractExpiry { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                int years = new DateTime(DateTime.Now.Subtract(DateOfBirth).Ticks).Year - 1;
                return years;
            }
        }
    }
}
