namespace AkriStat.ViewModels.Search
{
    public class StandardSearchResultVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        #region Player Only
        public string Position { get; set; }
        public string NationalityFlagUrl { get; set; }
        public string PictureUrl { get; set; }
        #endregion

        #region Team Only
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        #endregion
    }
}
