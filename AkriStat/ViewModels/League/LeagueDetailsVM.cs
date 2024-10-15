using AkriStat.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AkriStat.ViewModels.League
{
    public class LeagueDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LeagueTableLineVM> LeagueTableLines { get; set; }
        public List<SelectListItem> Matchweeks { get; set; }
        public List<Matches> Matches { get; set; }
    }
}
