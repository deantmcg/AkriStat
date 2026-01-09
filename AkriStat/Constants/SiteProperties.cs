using System;

namespace AkriStat.Constants
{
    public class SiteProperties
    {
        public const string CurrentSeason = "2019-20";

        public static DateTime CurrentDate
        {
            get
            {
                var minusYears = DateTime.Now.Year - 2019;
                var adjustedDate = DateTime.Now.AddYears(-minusYears);

                return adjustedDate.Month >= 1 && adjustedDate.Month < 8
                    ? adjustedDate.AddYears(1)
                    : adjustedDate;
            }
        }

        public enum Page
        {
            Player,
            Team,
            Shortlist,
            Account
        }
    }
}
