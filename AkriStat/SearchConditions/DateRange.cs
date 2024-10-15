using System;

namespace AkriStat.SearchConditions
{
    public class DateRange
    {
        public DateTime? Min { get; set; }
        public DateTime? Max { get; set; }
        public bool IsNull
        {
            get
            {
                if (Min == null && Max == null)
                    return true;
                else
                    return false;
            }
        }
        public void SetNulls()
        {
            if (Min != null || Max != null)
            {
                if (Min == null)
                {
                    Min = DateTime.MinValue;
                }
                if (Max == null)
                {
                    Max = DateTime.MaxValue;
                }
            }
        }
    }
}
