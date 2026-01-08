using System;

namespace AkriStat.Helpers
{
    public static class Formatter
    {
        /* Converts money decimal to user-friendly currency string
           e.g. 35000000 > £35m */
        public static string GetCurrencyString (decimal value)
        {
            if (value == 0)
                return "-";

            if (value < 1000)
                return $"£{value}";

            if (value < 10000)
                return String.Format("£{0:#,.##}k", value - 5);

            if (value < 100000)
                return String.Format("£{0:#,.#}k", value - 50);

            if (value < 1000000)
                return String.Format("£{0:#,.}k", value - 500);

            if (value < 10000000)
                return String.Format("£{0:#,,.##}m", value - 5000);

            if (value < 100000000)
                return String.Format("£{0:#,,.#}m", value - 50000);

            if (value < 1000000000)
                return String.Format("£{0:#,,.}m", value - 500000);

            return String.Format("£{0:#,,,.##}B", value - 5000000);
        }

        public static string GetCurrencyString(double value)
        {
            return GetCurrencyString(Convert.ToDecimal(value));
        }
    }
}
