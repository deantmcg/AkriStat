using AkriStat.Constants;
using AkriStat.Models;
using AkriStat.ViewModels.Viz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AkriStat.Controllers
{
    public class VizController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IConfiguration _configuration;

        public VizController(AkriStatDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet, Route("Viz")]
        public IActionResult Generate()
        {
            var viewModel = new VizGenerateVM();
            PopulateSelectLists(viewModel);

            return View(viewModel);
        }

        [HttpPost, Route("Viz")]
        public IActionResult Generate(VizGenerateVM viewModel)
        {
            PopulateSelectLists(viewModel);

            viewModel.Success = IsVizValid(viewModel);
            if (!viewModel.Success.Value)
            {
                return View(viewModel);
            }

            var resultsVM = new VizResultsVM() { Criteria = viewModel };

            var query = GenerateQuery(viewModel);

            var conString = Environment.GetEnvironmentVariable("ConnectionStrings__DEV");
            //var conString = _configuration.GetConnectionString("DEV");

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var dt = new DataTable();

                    connection.Open();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            var vizData = new VizData()
                            {
                                ID = (int)row["PlayerID"],
                                Name = row["PlayerName"].ToString()
                            };

                            for (int i = 2; i < row.ItemArray.Length; i++)
                            {
                                vizData.Data.Add(Convert.ToDouble(row.ItemArray[i]));
                            }

                            resultsVM.Data.Add(vizData);
                        }
                    }
                }
            }

            ViewData["Title"] = "Viz Results";
            return View("Viewer", resultsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCriteria(VizGenerateVM viewModel)
        {
            PopulateSelectLists(viewModel);
            ViewData["Title"] = "Viz Generator";
            return View("Generate", viewModel);
        }

        #region Helper Methods
        private string GenerateQuery(VizGenerateVM viewModel)
        {
            var columns = new List<string>() { "PlayerID", "PlayerName" };

            foreach (var dataPoint in viewModel.DataPoints)
            {
                columns.Add(dataPoint);
            }

            var query = new Query("PlayerMatchLogSummaries")
                .Select(columns.ToArray())
                .Where("Season", SiteProperties.CurrentSeason)
                .Where("MinutesPlayed", ">", viewModel.MinutesPlayed)
                .WhereIn("PlayerID", viewModel.PlayerIds);

            var compiler = new SqlServerCompiler();
            var result = compiler.Compile(query);

            return result.ToString();
        }

        private bool IsVizValid(VizGenerateVM viewModel)
        {
            bool valid = true;

            if (String.IsNullOrEmpty(viewModel.VizType))
                return false;

            if (viewModel.VizType.Equals("scatter"))
            {
                if (viewModel.DataPoints == null || viewModel.DataPoints.Count() != 2)
                {
                    valid = false;
                    viewModel.ErrorMessages.Add("Two data points required for scatter plot.");
                }
                if (viewModel.PlayerIds == null || viewModel.PlayerIds.Count() < 2)
                {
                    valid = false;
                    viewModel.ErrorMessages.Add("Minimum two players required.");
                }
            }

            return valid;
        }

        private VizGenerateVM PopulateSelectLists(VizGenerateVM viewModel)
        {
            viewModel.PlayersSelectList = _context.Players
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem()
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                })
                .ToList();

            return viewModel;
        }
        #endregion
    }
}
