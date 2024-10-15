namespace AkriStat.ViewModels.Dashboard
{
    public class TopPerformersVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Goals { get; set; }
        public decimal Xg { get; set; }
        public int Assists { get; set; }
        public decimal XgAssisted { get; set; }
        public decimal PassesCompletedPer90 { get; set; }
        public decimal PassesCompletedPerGame { get; set; }
        public int GkCleanSheets { get; set; }
        public int DribblersTackled { get; set; }
        public decimal GkPostShotXgPer90 { get; set; }
        public decimal GkPostShotXgPerGame { get; set; }
        public decimal CarriesPer90 { get; set; }
        public decimal CarriesPerGame { get; set; }
    }
}
