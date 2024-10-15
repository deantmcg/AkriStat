using AkriStat.Helpers;
using AkriStat.Models;
using AkriStat.ViewModels.Player;
using AkriStat.ViewModels.Search;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AkriStat.ViewModels.Team
{
    public class TeamDetailsVM
    {
        public int ID { get; set; }
        public string FbRefID { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string CrestUrl { get; set; }
        public int? YearFounded { get; set; }
        public string StadiumName { get; set; }
        public string Address { get; set; }
        public int NationID { get; set; }
        public string NationName { get; set; }
        public string NationFlagUrl { get; set; }
        public int CurrentLeagueID { get; set; }
        public string CurrentLeagueName { get; set; }
        public int TeamTypeID { get; set; }
        public string ColourCode1 { get; set; }
        public string ColourCode2 { get; set; }
        public string ColourCode3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal TotalValue { get; set; }
        public string TotalValueDisplay 
        { 
            get 
            {
                var formatter = new Formatter();
                return formatter.GetCurrencyString(TotalValue);
            } 
        }
        public List<AdvancedSearchResultVM> PlayerSummaries { get; set; }
        public List<LeagueTableLines> LeagueTableLines { get; set; }
        public List<MatchTeamStats> Matches { get; set; } = new List<MatchTeamStats>();
    }
}
