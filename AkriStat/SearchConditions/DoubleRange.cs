namespace AkriStat.SearchConditions
{
    public class DoubleRange
    {
        public double? Min { get; set; }
        public double? Max { get; set; }
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
                    Min = 0;
                }
                if (Max == null)
                {
                    Max = double.MaxValue;
                }
            }
        }
    }
}
