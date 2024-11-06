//using AkriStat.Helpers;
//using AkriStat.Models;
//using AkriStat.ViewModels.Scrape;
//using AutoMapper;
//using CsvHelper;
//using HtmlAgilityPack;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Security.Claims;
//using System.Threading;
//using System.Threading.Tasks;

//namespace AkriStat.Controllers
//{
//    [Authorize(Roles = "Administrator")]
//    public class ScrapeController : Controller
//    {
//        private readonly AkriStatDbContext _context;
//        private readonly IMapper _mapper;
//        protected static ScrapeClient client = new ScrapeClient();
//        private static Normalizer normalizer = new Normalizer();
//        private static string baseUrl = @"https://fbref.com";
//        private static string[] topFiveLeagues = new string[5] { "9", "12", "20", "11", "13" };
//        private static string[] matchLogTypes = new string[8] { "passing", "passing_types", "gca", "defense", "possession", "misc", "shooting", "keeper" };

//        public ScrapeController(AkriStatDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            ViewData["Title"] = "Scraper";
//            return View();
//        }

//        // Returns an Index view of all match log imports
//        [HttpGet, Route("/Scrape/Imports")]
//        public IActionResult ImportIndex()
//        {
//            var viewModels = _context.MatchLogImports
//                .Include(x => x.Player)
//                //.Include(x => x.ScrapeBatchJobs)
//                .OrderByDescending(x => x.DateScraped)
//                .Select(x => new ImportIndexVM()
//                {
//                    ID = x.ID,
//                    PlayerID = x.PlayerID,
//                    PlayerName = x.Player.Name,
//                    DateScraped = x.DateScraped,
//                    Executed = x.Executed,
//                    DateExecuted = x.DateExecuted,
//                    Season = x.ScrapeBatchJobs.First().Season,
//                    Success = x.Success
//                })
//                .ToList();

//            ViewData["Title"] = "Imports";
//            return View(viewModels);
//        }

//        // Returns an Index view of all scrape batches
//        [HttpGet, Route("Scrape/Batches")]
//        public IActionResult BatchIndex()
//        {
//            var viewModels = _context.ScrapeBatches
//                .Include(x => x.ScrapeBatchJobs)
//                .Include(x => x.CreatedByNavigation)
//                .OrderByDescending(x => x.CreatedDate)
//                .Select(x => new BatchIndexVM()
//                {
//                    ID = x.ID,
//                    CreatedDate = x.CreatedDate,
//                    CreatedBy = x.CreatedByNavigation.FullName,
//                    // set the number of jobs within batch
//                    ScrapeCount = x.ScrapeBatchJobs.Count()
//                })
//                .ToList();

//            ViewData["Title"] = "Batches";
//            return View(viewModels);
//        }

//        // Gets the scrape batch matching supplied id and returns its Details page
//        [HttpGet, Route("/Scrape/Batches/{id}")]
//        public IActionResult BatchDetails(int id)
//        {
//            var viewModel = _context.ScrapeBatches
//                .Include(x => x.ScrapeBatchJobs)
//                .ThenInclude(x => x.QueryPlayer)
//                .Select(x => new BatchDetailsVM()
//                {
//                    ID = x.ID,
//                    CreatedBy = x.CreatedByNavigation.FullName,
//                    CreatedDate = x.CreatedDate,
//                    // Gets all jobs associated with batch
//                    Jobs = x.ScrapeBatchJobs.Select(y => new BatchJobIndexVM()
//                    {
//                        ID = y.ID,
//                        FbRefID = y.QueryFbRefID,
//                        PlayerID = y.QueryPlayerID,
//                        PlayerName = y.QueryPlayer.Name,
//                        Successful = y.Successful,
//                        ImportID = y.ImportID,
//                        ErrorMessage = y.ErrorMessage
//                    }).ToList()
//                })
//                .FirstOrDefault(x => x.ID == id);

//            ViewData["Title"] = "Batch Details";
//            return View(viewModel);
//        }

//        // Returns the view used for starting a new match log scrape
//        [HttpGet]
//        public IActionResult New()
//        {
//            var viewModel = new ScrapeDetailsVM();
//            PopulateSelectLists(viewModel);

//            ViewData["Title"] = "New Scrape";
//            return View(viewModel);
//        }

//        /* jQuery will post here from New() to create a batch
//         * batch id is returned to view and StartScrape(new_batch_id) is called
//         */
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateBatch(ScrapeDetailsVM viewModel)
//        {
//            var batch = new ScrapeBatches()
//            {
//                CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier),
//                CreatedDate = DateTime.Now
//            };

//            // create job for each existing player selected
//            if (viewModel.PlayerIds != null)
//            {
//                foreach (var id in viewModel.PlayerIds)
//                {
//                    batch.ScrapeBatchJobs.Add(new ScrapeBatchJobs()
//                    {
//                        QueryPlayerID = id,
//                        Season = viewModel.Season
//                    });
//                }
//            }

//            // create job for each FbRefId entered
//            if (viewModel.FbRefIds != null)
//            {
//                viewModel.FbRefIds = viewModel.FbRefIds.Replace(" ", ",").Replace("\r\n", ",");

//                foreach (var fbRefId in viewModel.FbRefIds.Split(",").Distinct())
//                {
//                    if (!String.IsNullOrEmpty(fbRefId))
//                    {
//                        batch.ScrapeBatchJobs.Add(new ScrapeBatchJobs()
//                        {
//                            QueryFbRefID = fbRefId,
//                            Season = viewModel.Season
//                        });
//                    }
//                }
//            }

//            _context.ScrapeBatches.Add(batch);
//            await _context.SaveChangesAsync();

//            // returns json to be used in Scrape/New
//            return Json(new { batchId = batch.ID });
//        }

//        // Gets batch using supplied batchId and processes its jobs
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> StartScrape(int batchId)
//        {
//            // get batch
//            var batch = _context.ScrapeBatches.Include(x => x.ScrapeBatchJobs).FirstOrDefault(x => x.ID == batchId);

//            // process each job
//            foreach (var job in batch.ScrapeBatchJobs)
//            {
//                await ScrapePlayerMatchLogs(job);
//            }

//            return Ok();
//        }

//        // Processes a scrape batch job
//        public async Task ScrapePlayerMatchLogs(ScrapeBatchJobs job)
//        {
//            var combinedMatchLogs = new List<string>();
//            int count = 0;
//            Players player;

//            // set variables to prevent changes being made to job properties
//            var playerId = job.QueryPlayerID;
//            var playerFbRefId = job.QueryFbRefID;
//            var season = job.Season;

//            if (playerId != null) // get player by id
//            {
//                player = _context.Players.FirstOrDefault(x => x.ID == playerId.Value);
//            }
//            else // get player by FbRefId
//            {
//                player = _context.Players.FirstOrDefault(x => x.FbRefID.Equals(playerFbRefId));
//            }

//            if (player == null) // scrape player details if doesn't exist in database
//            {
//                player = ScrapePlayerDetails(playerFbRefId, job.Season);

//                // if still null after trying to scrape player details
//                if (player == null)
//                {
//                    // invalid player id
//                    if (playerId != null)
//                    {
//                        job.Successful = false;
//                        job.ErrorMessage = $"Could not find player of ID {playerId.Value}";
//                    }
//                    // invalid player FbRefId
//                    else
//                    {
//                        job.Successful = false;
//                        job.ErrorMessage = $"Could not find player of FbRef ID {playerFbRefId}";
//                    }
//                    await _context.SaveChangesAsync();
//                    return;
//                }
//            }
//            else
//            {
//                if (playerFbRefId == null)
//                {
//                    playerFbRefId = player.FbRefID;
//                }

//                var test = _context.PlayerMatchLogs.Include(x => x.Match).Where(x => x.PlayerID == playerId && x.Match.Season.Equals(season)).Count();

//                // Check if player has match logs already for the chosen season
//                if (_context.PlayerMatchLogs.Include(x => x.Match).Where(x => x.PlayerID == player.ID && x.Match.Season.Equals(season)).Count() > 0)
//                {
//                    job.Successful = false;
//                    job.ErrorMessage = $"Player already has Match Logs for {season}";
//                    await _context.SaveChangesAsync();
//                    return;
//                }
//                // Check if players has pending match log imports
//                if (_context.ScrapeBatchJobs.Where(x => x.ID != job.ID && (x.Successful == null || !x.Successful.Value) &&
//                        ((x.QueryFbRefID != null && x.QueryFbRefID.Equals(playerFbRefId)) ||
//                        (x.QueryPlayerID != null && x.QueryPlayerID == player.ID))).Count() > 0)
//                {
//                    job.Successful = false;
//                    job.ErrorMessage = $"Player has a pending import for {season}";
//                    await _context.SaveChangesAsync();
//                    return;
//                }
//            }

//            playerId = player.ID;
//            player = null;

//            // players base page on FbRef.com
//            var playerHomeUrl = $"{baseUrl}/en/players/{playerFbRefId}/";
//            var web = new HtmlWeb();
//            var doc = web.Load(playerHomeUrl);

//            /* gets players matchlogs summary page
//               summary can be replaced with each matchLogType */
//            var summaryPageUrl = baseUrl + doc.DocumentNode
//                .Descendants("a")
//                .Select(x => x.GetAttributeValue("href", ""))
//                // FbRef uses yyyy-yy we use yyyy-yyyy
//                .Where(x => x.Contains("summary") && x.Contains(season.Replace("-", "-20")))
//                .FirstOrDefault();

//            foreach (var matchLogType in matchLogTypes)
//            {
//                try
//                {
//                    // replace summary in url with current match log type
//                    var url = summaryPageUrl.Replace("summary", matchLogType);
//                    doc = web.Load(url);
//                    var table = doc.DocumentNode
//                                        .Descendants("table")
//                                        .SingleOrDefault();

//                    // match log table rows on players' FbRef page
//                    var tableRows = table.Descendants("tr")
//                        .Where(x => x.GetClasses().Count() == 0)
//                        .ToList();
//                    tableRows.RemoveAt(tableRows.Count - 1);

//                    // iterated when match log isn't for a match in top 5 leagues
//                    int skipped = 0;

//                    for (int i = 0; i < tableRows.Count(); i++)
//                    {
//                        string line;

//                        if (tableRows[i].Descendants("th").Select(x => x.InnerText).Count() > 1)
//                        {
//                            // get the data headers eg. passes_completed, goals, shots
//                            line = string.Join(",", tableRows[i].Descendants("th").Select(x => x.GetAttributeValue("data-stat", x.InnerText).Replace(",", "|")));
//                        }
//                        else
//                        {
//                            var list = new List<string>();
//                            // Get all row contents 
//                            list.AddRange(tableRows[i].Descendants("th").Select(x => x.InnerText.Replace(",", "|")));
//                            list.AddRange(tableRows[i].Descendants("td").Select(x => x.InnerText.Replace(",", "|")));
//                            // Get competition id instead of name
//                            list[2] = tableRows[i].Descendants("td").ElementAt(2).Descendants("a").First().GetAttributeValue("href", "").Split("/")[3];
//                            if (!topFiveLeagues.Contains(list[2]))
//                            {
//                                // if match not in top 5 leagues: skip
//                                skipped++;
//                                continue;
//                            }
//                            // Get team ids instead of names
//                            list[6] = tableRows[i].Descendants("td").ElementAt(5).Descendants("a").First().GetAttributeValue("href", "").Split("/")[3];
//                            list[7] = tableRows[i].Descendants("td").ElementAt(6).Descendants("a").First().GetAttributeValue("href", "").Split("/")[3];
//                            line = string.Join(",", list.ToArray()).Replace("&ndash;", "-");
//                        }

//                        var tempLine = line.Split(",").ToList();

//                        // if not first match log type: remove duplicated data
//                        if (count > 0)
//                        {
//                            tempLine.RemoveRange(0, 11);
//                        }

//                        // removes Match Report hyperlink
//                        tempLine.RemoveAt(tempLine.Count() - 1);
//                        line = string.Join(",", tempLine);

//                        // if first match log type: add new list record
//                        if (count == 0)
//                        {
//                            combinedMatchLogs.Add(line);
//                        }
//                        // if not first match log type: append to current list record
//                        else
//                        {
//                            combinedMatchLogs[i - skipped] = combinedMatchLogs[i - skipped] + "," + line;
//                        }
//                    }

//                    count++;
//                }
//                catch (Exception e)
//                {
//                    job.Successful = false;
//                    job.ErrorMessage = $"{player.Name} ({playerId.Value}) scrape failed for {matchLogType}.";
//                    return;
//                }
//            }

//            var file = GetCsvByteArray(combinedMatchLogs);
//            var import = new MatchLogImports()
//            {
//                PlayerID = playerId.Value,
//                MatchLogImportFiles = new MatchLogImportFiles()
//                {
//                    Bytes = file
//                }
//            };
//            _context.MatchLogImports.Add(import);

//            job.Successful = true;
//            await _context.SaveChangesAsync();
//            job.ImportID = import.ID;
//            await _context.SaveChangesAsync();

//            Thread.Sleep(5000); // wait 5 seconds between scrapes to prevent overloading FbRef
//        }

//        [HttpGet]
//        public async Task<IActionResult> DownloadImportCsv(int importId)
//        {
//            var file = await _context.MatchLogImportFiles
//                .Include(x => x.Import.Player)
//                .Include(x => x.Import.ScrapeBatchJobs)
//                .FirstOrDefaultAsync(x => x.ImportID == importId);

//            return File(file.Bytes, "text/csv", $"{file.Import.Player.Name} {file.Import.ScrapeBatchJobs.First().Season}.csv");
//        }

//        // Converts match logs list to byte[]
//        private static byte[] GetCsvByteArray(List<string> combinedMatchLogs)
//        {
//            using (var memoryStream = new MemoryStream())
//            using (var streamWriter = new StreamWriter(memoryStream))
//            using (var streamReader = new StreamReader(memoryStream))
//            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
//            {
//                foreach (var record in combinedMatchLogs.Select(x => x.Split(",")))
//                {
//                    foreach (var field in record)
//                    {
//                        csvWriter.WriteField(field);
//                    }

//                    csvWriter.NextRecord();
//                }
//                csvWriter.Flush();
//                memoryStream.Position = 0;

//                return memoryStream.ToArray();
//            }
//        }

//        // Gets new player details by scraping their FbRef.com page
//        private Players? ScrapePlayerDetails(string playerFbRefId, string season)
//        {
//            var player = new Players();
//            player.FbRefID = playerFbRefId;

//            var positions = _context.Positions
//                .Select(x => new
//                {
//                    ID = x.ID,
//                    Code = x.Code
//                })
//                .ToList();

//            var countries = _context.Countries
//                .Select(x => new
//                {
//                    ID = x.ID,
//                    Name = x.Name
//                })
//                .ToList();

//            try
//            {
//                string country = "";

//                // Load players match log page
//                var url = $"https://fbref.com/en/players/{playerFbRefId}/";
//                var web = new HtmlWeb();
//                var doc = web.Load(url);

//                var childNodesCount = doc.DocumentNode
//                .Descendants("div")
//                .Where(x => x.InnerHtml.Contains("https://schema.org/Person"))
//                .Last()
//                .ChildNodes.Count();

//                var div = doc.DocumentNode
//                .Descendants("div")
//                .Where(x => x.InnerHtml.Contains("https://schema.org/Person"))
//                .Last()
//                .ChildNodes[childNodesCount - 2];

//                player.Name = div.Descendants("h1")
//                    .First()
//                    .Descendants("span")
//                    .First()
//                    .InnerText
//                    .Replace(",", "|");

//                player.NormalizedName = normalizer.NormalizeString(player.Name);

//                player.FullName = div.Descendants("strong")
//                    .First()
//                    .InnerText
//                    .Replace(",", "|");

//                if (player.FullName.Equals("Position:"))
//                    player.FullName = null;
//                else
//                    player.NormalizedFullName = normalizer.NormalizeString(player.FullName);

//                try
//                {
//                    var footed = div.Descendants("p")
//                        .Where(x => x.InnerText.Contains("Position:"))
//                        .First()
//                        .InnerText
//                        .Split(" ")
//                        .Last()
//                        .Replace("*", "");

//                    footed = char.ToUpper(footed[0]) + footed.Substring(1);

//                    player.Footed = footed;
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.InnerException);
//                }

//                try
//                {
//                    player.Height = Convert.ToDecimal(div.Descendants("span")
//                        .Where(x => x.Attributes.Select(y => y.Value).Contains("height"))
//                        .First()
//                        .InnerText
//                        .Replace("cm", ""));
//                }
//                catch (Exception)
//                { }

//                try
//                {
//                    player.Weight = Convert.ToInt32(div.Descendants("span")
//                        .Where(x => x.Attributes.Select(y => y.Value).Contains("weight"))
//                        .First()
//                        .InnerText
//                        .Replace("kg", ""));
//                }
//                catch (Exception)
//                { }

//                List<int> dob;

//                try
//                {
//                    dob = div.Descendants("span")
//                        .Where(x => x.Attributes.Select(y => y.Name).Contains("data-birth"))
//                        .First()
//                        .GetAttributeValue("data-birth", null)
//                        .Replace(",", "|")
//                        .Split("-")
//                        .Select(x => Convert.ToInt32(x))
//                        .ToList();
//                }
//                catch (Exception)
//                {
//                    var rawDob = div.Descendants("span")
//                        .Where(x => x.Attributes.Select(y => y.Value).Contains("birthDate"))
//                        .First()
//                        .InnerText.Replace(",", "").Replace("\n", "")
//                        .Split(" ").Where(x => !String.IsNullOrEmpty(x)).ToList();

//                    dob = new List<int>()
//                    {
//                        Convert.ToInt32(rawDob[2]),
//                        Convert.ToInt32(MonthTextToNumber(rawDob[0])),
//                        Convert.ToInt32(rawDob[1])
//                    };
//                }

//                try
//                {
//                    player.DateOfBirth = new DateTime
//                        (
//                            dob[0],
//                            dob[1],
//                            dob[2]
//                        );
//                }
//                catch (Exception)
//                { }

//                try
//                {
//                    country = div.Descendants("p")
//                        .Where(x => x.InnerText.Contains("National Team:"))
//                        .First()
//                        .InnerText
//                        .Replace("&nbsp;", "")
//                        .Replace("National Team:", "")
//                        .Replace(" br", "")
//                        .Replace(",", "|");

//                    player.NationalityID = countries.FirstOrDefault(x => country.Contains(x.Name)).ID;
//                }
//                catch (Exception)
//                {
//                    country = div.Descendants("p")
//                        .Where(x => x.InnerText.Contains("Citizenship:"))
//                        .First()
//                        .InnerText
//                        .Replace("&nbsp;", "")
//                        .Replace("Citizenship:", "")
//                        .Replace(" br", "")
//                        .Replace(",", "|");

//                    player.NationalityID = countries.FirstOrDefault(x => country.Contains(x.Name)).ID;
//                }

//                try
//                {
//                    player.PlaceOfBirth = div.Descendants("span")
//                        .Where(x => x.Attributes.Select(y => y.Value).Contains("birthPlace"))
//                        .First()
//                        .InnerText
//                        .Split("in ")
//                        .ElementAt(1)
//                        .Split("\n")
//                        .First();
//                }
//                catch (Exception)
//                { }


//                string currentTeam = String.Empty;

//                try
//                {
//                    currentTeam = doc.DocumentNode.Descendants("table").First()
//                        .Descendants("tbody").First()
//                        .Descendants("td")
//                        .Where(x => x.GetAttributeValue("data-stat", "").Equals("squad"))
//                        .Last()
//                        .Descendants("a").First().InnerText;
//                }
//                catch (Exception)
//                {
//                    try
//                    {
//                        currentTeam = div.Descendants("p")
//                        .FirstOrDefault(x => x.InnerHtml.Contains("Club:"))
//                        .Descendants("a")
//                        .First()
//                        .InnerText;
//                    }
//                    catch (Exception)
//                    {
//                    }
//                }

//                ScrapeTransferMarkt(player, currentTeam);
//                GetContractDetails(player, currentTeam);
//                _context.Players.Add(player);
//                _context.SaveChanges();
//                return player;

//            }
//            catch (Exception e)
//            {
//                Console.Write($"{playerFbRefId} - {e.Message}");
//                return null;
//            }
//        }

//        // Populates extra details for a new player from Transfermarkt.com
//        private void ScrapeTransferMarkt(Players player, string currentTeam)
//        {
//            var searchUrl = $"https://www.google.com/search?q=transfermarkt+{player.Name.Replace(" ", "+")}+{currentTeam.Replace(" ", "+")}";

//            // Search 'Transfermarkt', players' name and current team on Google
//            var web = new HtmlWeb();
//            var doc = web.Load(searchUrl);

//            // Gets players Transfermarkt url from Google results
//            var transferMarktUrl = doc.DocumentNode
//                .Descendants("a")
//                .Where(x => x.InnerText.Contains("Player profile"))
//                .FirstOrDefault()
//                .GetAttributeValue("href", "")
//                .Split("&").First()
//                .Replace("/url?q=", "");

//            player.TransfermarktID = transferMarktUrl.Split("/").Last();

//            web = new HtmlWeb();
//            doc = web.Load(transferMarktUrl);

//            player.FacePictureUrl = doc.DocumentNode
//                .Descendants()
//                .Where(x => x.HasClass("dataBild"))
//                .First()
//                .Descendants("img")
//                .First()
//                .GetAttributeValue("src", "");

//            try
//            {
//                player.FullName = doc.DocumentNode
//                .Descendants("tr")
//                .Where(x => x.InnerText.Contains("Name in home country:"))
//                .First()
//                .Descendants("td")
//                .First()
//                .InnerText;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.InnerException);
//            }

//            if (player.PositionID == 0)
//            {
//                try
//                {
//                    var position = doc.DocumentNode
//                        .Descendants("p")
//                        .FirstOrDefault(x => x.InnerHtml.Contains("Position:"))
//                        .Descendants()
//                        .FirstOrDefault(x => x.HasClass("dataValue"))
//                        .InnerText.Trim();

//                    player.PositionID = GetPositionID(position);
//                }
//                catch (Exception e)
//                { }
//            }

//            if (player.Height == null)
//            {
//                try
//                {
//                    player.Height = Convert.ToDecimal(doc.DocumentNode
//                        .Descendants("span")
//                        .Where(x => x.OuterHtml.Contains("height"))
//                        .ToList()[0]
//                        .InnerText
//                        .Replace(" m", "cm")
//                        .Replace(",", ""));
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.InnerException);
//                }
//            }

//            if (String.IsNullOrEmpty(player.Footed))
//            {
//                try
//                {
//                    var footed = doc.DocumentNode
//                        .Descendants("tr")
//                        .Where(x => x.InnerText.Contains("Foot:"))
//                        .First()
//                        .Descendants("td")
//                        .First()
//                        .InnerText;

//                    footed = char.ToUpper(footed[0]) + footed.Substring(1);

//                    player.Footed = footed;
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.InnerException);
//                }
//            }

//            if (String.IsNullOrEmpty(player.PlaceOfBirth))
//            {
//                try
//                {
//                    player.PlaceOfBirth = doc.DocumentNode
//                        .Descendants("span")
//                        .Where(x => x.OuterHtml.Contains("birthPlace"))
//                        .ToList()[0]
//                        .InnerText
//                        .Replace("\n", "")
//                        .Replace("\t", "");
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.InnerException);
//                }
//            }

//            // checks if player has market values
//            var marketValueGraph = doc.DocumentNode
//                .Descendants("div")
//                .Where(x => x.Id.Equals("yw0"))
//                .FirstOrDefault();

//            // scrapes data from the Transfermarkt market value line graph
//            if (marketValueGraph != null)
//            {
//                var values = doc.DocumentNode
//                    .OuterHtml
//                    .Split("series")[1]
//                    .Split("},{")
//                    .ToList();

//                var valuesList = new List<dynamic>();

//                for (int i = 0; i < values.Count; i++)
//                {
//                    try
//                    {
//                        dynamic value = new ExpandoObject();
//                        try
//                        {
//                            value.Money = values[i].Split("u00A3")[1].Split("'")[0];
//                        }
//                        catch (Exception)
//                        {
//                            value.Money = values[i].Split("u20AC")[1].Split("'")[0];
//                        }
//                        var rawDate = values[i].Split("datum_mw':'")[1].Split("'")[0].Replace(",", "");
//                        var year = rawDate.Split("\\x20")[2];
//                        var month = MonthTextToNumber(rawDate.Split("\\x20")[0]);
//                        var day = rawDate.Split("\\x20")[1];
//                        if (day.Length == 1)
//                            day = "0" + day;

//                        value.Date = $"{year}-{month}-{day}";

//                        value.Club = ConvertUnicode(values[i].Split("'verein':'")[1].Split("'")[0]);

//                        valuesList.Add(value);
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine(e.InnerException);
//                    }
//                }

//                player.Value = MoneyStringToDecimal(valuesList.Where(x =>
//                    new DateTime
//                    (
//                        Convert.ToInt32(x.Date.Split("-")[0]),
//                        Convert.ToInt32(x.Date.Split("-")[1]),
//                        Convert.ToInt32(x.Date.Split("-")[2])
//                    )
//                    < new DateTime(2020, 09, 01)).Last().Money);
//                player.MarketValueJson = JsonConvert.SerializeObject(valuesList);
//            }

//            var socials = doc.DocumentNode
//                .Descendants("tr")
//                .Where(x => x.InnerText.Contains("Social-Media:"))
//                .FirstOrDefault();

//            if (socials != null)
//            {
//                if (socials.InnerHtml.Contains("twitter"))
//                {
//                    player.TwitterUrl = socials.Descendants("td")
//                        .FirstOrDefault()
//                        .Descendants("a")
//                        .Where(x => x.InnerHtml.Contains("twitter"))
//                        .First()
//                        .GetAttributeValue("href", "");
//                }
//                if (socials.InnerHtml.Contains("instagram"))
//                {
//                    player.InstagramUrl = socials.Descendants("td")
//                        .FirstOrDefault()
//                        .Descendants("a")
//                        .Where(x => x.InnerHtml.Contains("instagram"))
//                        .First()
//                        .GetAttributeValue("href", "");
//                }
//                if (socials.InnerHtml.Contains("facebook"))
//                {
//                    player.FacebookUrl = socials.Descendants("td")
//                        .FirstOrDefault()
//                        .Descendants("a")
//                        .Where(x => x.InnerHtml.Contains("facebook"))
//                        .First()
//                        .GetAttributeValue("href", "");
//                }
//            }
//        }

//        // Gets contract details for new player from the Football Manager game database
//        private void GetContractDetails(Players player, string currentTeam)
//        {
//            try
//            {
//                var searchUrl = $"https://www.google.com/search?q=+football+manager+2020+sortitoutsi+{player.Name.Replace(" ", "+")}+{currentTeam.Replace(" ", "+")}";
//                var web = new HtmlWeb();
//                var doc = web.Load(searchUrl);

//                var sortitoutsiUrl = doc.DocumentNode
//                    .Descendants("a")
//                    .Where(x => x.InnerText.Contains("Sortitoutsi"))
//                    .FirstOrDefault()
//                    .GetAttributeValue("href", "");

//                web = new HtmlWeb();
//                doc = web.Load(sortitoutsiUrl);

//                var contractExpiry = doc.DocumentNode
//                    .Descendants("dt")
//                    .Where(x => x.InnerText.Contains("Contract Expires"))
//                    .First().NextSibling.NextSibling.InnerText;

//                player.ContractExpiry = new DateTime
//                    (
//                        Convert.ToInt32(contractExpiry.Split("-")[2]),
//                        Convert.ToInt32(contractExpiry.Split("-")[1]),
//                        Convert.ToInt32(contractExpiry.Split("-")[0])
//                    );

//                player.WeeklyWage = Convert.ToDecimal(doc.DocumentNode
//                    .Descendants("dt")
//                    .Where(x => x.InnerText.Contains("Wage"))
//                    .First().NextSibling.NextSibling.InnerText.Replace("&pound;", ""));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.InnerException);
//            }
//        }

//        public async Task<IActionResult> GetTeamPlayerFbRefIds(string teamFbRefId, string season)
//        {
//            var url = $"{baseUrl}/en/squads/{teamFbRefId}/{season.Replace("-", "-20")}";
//            var web = new HtmlWeb();
//            var doc = web.Load(url);

//            var playerFbRefIds = doc.DocumentNode.Descendants("th")
//                .Where(x => x.InnerHtml.Contains("/players/"))
//                .Select(x => x.Descendants("a").First().GetAttributeValue("href", "").Split("players/")[1].Split("/")[0])
//                .Distinct().ToList();

//            return Json(new { FbRefIds = String.Join(",", playerFbRefIds) });
//        }

//        [Route("Imports/{importId}/Execute")]
//        public async Task<IActionResult> ExecuteImport(int importId)
//        {
//            var import = await _context.MatchLogImports
//                .Include(x => x.MatchLogImportFiles)
//                .Include(x => x.ScrapeBatchJobs)
//                .Include(x => x.Player)
//                .FirstOrDefaultAsync(x => x.ID == importId);

//            var helper = new ImportHelper(import.MatchLogImportFiles.Bytes);

//            if (helper.CsvLines.Count() > 0)
//            {
//                for (int i = 0; i < helper.CsvLines.Count(); i++)
//                {
//                    var match = await GetMatch(helper.CsvLines[i], import.ScrapeBatchJobs.First().Season);
//                    var venue = helper.GetValueByHeaderName(i, "venue");
//                    var matchLog = new PlayerMatchLogs()
//                    {
//                        PlayerID = import.PlayerID,
//                        MatchID = match.ID,
//                        TeamID = venue.Equals("Home") ? match.TeamOneID : match.TeamTwoID
//                    };

//                    if (await _context.PlayerMatchLogs
//                        .FirstOrDefaultAsync(x => x.PlayerID == import.PlayerID
//                        && x.MatchID == match.ID) != null)
//                    {
//                        continue;
//                    }

//                    var columns = helper.ColumnData.Where(x => !String.IsNullOrEmpty(x.DbColumnName)).Select(x => x.DbColumnName).ToArray();

//                    //foreach (var property in matchLog.GetType().GetProperties().Where(x => columns.Contains(x.Name)))
//                    foreach (var property in matchLog.GetType().GetProperties())
//                    {
//                        if (property.Name.StartsWith("Gk") && !helper.GetValue(i, "PositionPlayed").Contains("Gk"))
//                            continue;

//                        if (property.Name.ToLower().EndsWith("id"))
//                            continue;

//                        switch (property.Name)
//                        {
//                            case "Started":
//                                matchLog.Started = helper.GetValue(i, "Started").Contains("Y");
//                                break;
//                            case "ShotsOnTargetPercentage":
//                                matchLog.ShotsOnTargetPercentage = CalculatePercentage(helper.GetValue(i, "ShotsOnTarget"), helper.GetValue(i, "Shots"));
//                                break;
//                            case "AerialDualsWonPercentage":
//                                matchLog.AerialDualsWonPercentage = CalculatePercentage(ToInteger(helper.GetValue(i, "AerialDualsWon")),
//                                    ToInteger(helper.GetValue(i, "AerialDualsWon") + ToInteger(helper.GetValue(i, "AerialDualsLost"))));
//                                break;
//                            case "DribblersTackledPercentage":
//                                matchLog.DribblersTackledPercentage = CalculatePercentage(helper.GetValue(i, "DribblersTackled"), helper.GetValue(i, "DribblesContested"));
//                                break;
//                            case "SuccessfulPressuresPercentage":
//                                matchLog.SuccessfulPressuresPercentage = CalculatePercentage(helper.GetValue(i, "SuccessfulPressures"), helper.GetValue(i, "Pressures"));
//                                break;
//                            case "ShortPassesCompletedPercentage":
//                                matchLog.ShortPassesCompletedPercentage = CalculatePercentage(helper.GetValue(i, "ShortPassesCompleted"), helper.GetValue(i, "ShortPassesAttempted"));
//                                break;
//                            case "MediumPassesCompletedPercentage":
//                                matchLog.MediumPassesCompletedPercentage = CalculatePercentage(helper.GetValue(i, "MediumPassesCompleted"), helper.GetValue(i, "MediumPassesAttempted"));
//                                break;
//                            case "LongPassesCompletedPercentage":
//                                matchLog.LongPassesCompletedPercentage = CalculatePercentage(helper.GetValue(i, "LongPassesCompleted"), helper.GetValue(i, "LongPassesAttempted"));
//                                break;
//                            case "PassesCompletedPercentage":
//                                matchLog.PassesCompletedPercentage = CalculatePercentage(helper.GetValue(i, "PassesCompleted"), helper.GetValue(i, "PassesAttempted"));
//                                break;
//                            case "ProgressivePassesPercentage":
//                                matchLog.ProgressivePassesPercentage = CalculatePercentage(helper.GetValue(i, "ProgressivePasses"), helper.GetValue(i, "PassesCompleted"));
//                                break;
//                            case "SuccessfulDribblesPercentage":
//                                matchLog.SuccessfulDribblesPercentage = CalculatePercentage(helper.GetValue(i, "SuccessfulDribbles"), helper.GetValue(i, "DribblesAttempted"));
//                                break;
//                            case "PassesReceivedPercentage":
//                                matchLog.PassesReceivedPercentage = CalculatePercentage(helper.GetValue(i, "PassesReceived"), helper.GetValue(i, "WasTargetOfPass"));
//                                break;
//                            case "GkSavesPercentage":
//                                matchLog.GkSavesPercentage = CalculatePercentage(ToInteger(helper.GetValue(i, "GkShotsOnTargetFaced")) - ToInteger(helper.GetValue(i, "GkGoalsConceded")),
//                                    ToInteger(helper.GetValue(i, "GkShotsOnTargetFaced")));
//                                break;
//                            case "GkPassesCompletedOver40YardsPercentage":
//                                matchLog.GkPassesCompletedOver40YardsPercentage = CalculatePercentage(helper.GetValue(i, "GkPassesCompletedOver40Yards"),
//                                    helper.GetValue(i, "GkPassesAttemptedOver40Yards"));
//                                break;
//                            case "GkCrossesStoppedPercentage":
//                                matchLog.GkCrossesStoppedPercentage = CalculatePercentage(helper.GetValue(i, "GkCrossesStopped"), helper.GetValue(i, "GkOpponentCrossesAttempted"));
//                                break;
//                            case "GoalsPerShot":
//                                matchLog.GoalsPerShot = Divide(helper.GetValue(i, "Goals"), helper.GetValue(i, "Shots"));
//                                break;
//                            case "GoalsPerShotOnTarget":
//                                matchLog.GoalsPerShotOnTarget = Divide(helper.GetValue(i, "Goals"), helper.GetValue(i, "ShotsOnTarget"));
//                                break;
//                            case "NonPenaltyXgPerShot":
//                                matchLog.NonPenaltyXgPerShot = Divide(helper.GetValue(i, "NonPenaltyXg"), helper.GetValue(i, "Shots"));
//                                break;
//                            case "GoalsMinusXG":
//                                matchLog.GoalsMinusXG = ToInteger(helper.GetValue(i, "Goals")) - ToDecimal(helper.GetValue(i, "XG"));
//                                break;
//                            case "NonPenaltyGoalsMinusXG":
//                                matchLog.NonPenaltyGoalsMinusXG = ToInteger(helper.GetValue(i, "Goals")) - ToInteger(helper.GetValue(i, "PenaltyKicksMade")) - ToDecimal(helper.GetValue(i, "XG"));
//                                break;
//                            case "ShotCreatingActions":
//                                matchLog.ShotCreatingActions = new int[] { ToInteger(helper.GetValue(i, "PassesCompletedLiveBallLeadingToShot")), ToInteger(helper.GetValue(i, "PassesCompletedDeadBallLeadingToShot")),
//                                    ToInteger(helper.GetValue(i, "DribblesLeadingToShot")), ToInteger(helper.GetValue(i, "ShotsLeadingToAnotherShot")), ToInteger(helper.GetValue(i, "FoulsDrawnLeadingToShot")) }.Sum();
//                                break;
//                            case "GoalCreatingActions":
//                                matchLog.GoalCreatingActions = ToInteger(helper.GetValue(i, "PassesCompletedLiveBallLeadingToGoal")) + ToInteger(helper.GetValue(i, "PassesCompletedDeadBallLeadingToGoal")) +
//                                    ToInteger(helper.GetValue(i, "DribblesLeadingToGoal")) + ToInteger(helper.GetValue(i, "ShotsLeadingToAnotherGoal")) + ToInteger(helper.GetValue(i, "FoulsDrawnLeadingToGoal"));
//                                break;
//                            case "Pressures":
//                                matchLog.Pressures = ToInteger(helper.GetValue(i, "PressuresDefensiveThird")) + ToInteger(helper.GetValue(i, "PressuresMiddleThird")) +
//                                    ToInteger(helper.GetValue(i, "PressuresAttackingThird"));
//                                break;
//                            case "PlayersTackledAndInterceptions":
//                                matchLog.PlayersTackledAndInterceptions = ToInteger(helper.GetValue(i, "PlayersTackled")) + ToInteger(helper.GetValue(i, "Interceptions"));
//                                break;
//                            case "PassesCompleted":
//                                matchLog.PassesCompleted = ToInteger(helper.GetValue(i, "ShortPassesCompleted")) + ToInteger(helper.GetValue(i, "MediumPassesCompleted")) +
//                                    ToInteger(helper.GetValue(i, "LongPassesCompleted"));
//                                break;
//                            case "PassesAttempted":
//                                matchLog.PassesAttempted = ToInteger(helper.GetValue(i, "ShortPassesAttempted")) + ToInteger(helper.GetValue(i, "MediumPassesAttempted")) +
//                                    ToInteger(helper.GetValue(i, "LongPassesAttempted"));
//                                break;
//                            case "CornerKicks":
//                                matchLog.CornerKicks = ToInteger(helper.GetValue(i, "CornerKicksInswinging")) + ToInteger(helper.GetValue(i, "CornerKicksOutswinging")) +
//                                    ToInteger(helper.GetValue(i, "CornerKicksStraight"));
//                                break;
//                            case "Touches":
//                                matchLog.Touches = ToInteger(helper.GetValue(i, "TouchesDefensiveThird")) + ToInteger(helper.GetValue(i, "TouchesMiddleThird")) +
//                                    ToInteger(helper.GetValue(i, "TouchesAttackingThird"));
//                                break;
//                            case "ChancesCreated":
//                                matchLog.ChancesCreated = ToInteger(helper.GetValue(i, "KeyPasses")) + ToInteger(helper.GetValue(i, "Assists"));
//                                break;
//                            default:
//                                {
//                                    var acceptedTypes = new string[] { "string", "int", "decimal", "boolean" };

//                                    if (acceptedTypes.Any(x => property.PropertyType.FullName.ToLower().Contains(x)))
//                                    {
//                                        var value = helper.GetValue(i, property.Name);

//                                        if (property.PropertyType.FullName.Contains("String"))
//                                        {
//                                            property.SetValue(matchLog, value);
//                                        }
//                                        else if (property.PropertyType.FullName.Contains("Int"))
//                                        {
//                                            property.SetValue(matchLog, ToInteger(value));
//                                        }
//                                        else if (property.PropertyType.FullName.Contains("Decimal"))
//                                        {
//                                            property.SetValue(matchLog, ToDecimal(value));
//                                        }
//                                        else if (property.Name.Contains("Card"))
//                                        {
//                                            property.SetValue(matchLog, ToInteger(helper.GetValue(i, "YellowCard")) == 1);
//                                        }
//                                    }
//                                    break;
//                                }
//                        }
//                    }

//                    _context.PlayerMatchLogs.Add(matchLog);
//                }
//            }

//            import.Executed = true;
//            import.DateExecuted = DateTime.Now;

//            if (import.Player.CurrentTeamID == null && helper.CsvLines.Count() > 0 &&
//                import.ScrapeBatchJobs.First().Season.Equals(Constants.SiteProperties.CurrentSeason))
//            {
//                var teamFbRefId = helper.GetValueByHeaderName(helper.CsvLines.Count() - 1, "squad");
//                import.Player.CurrentTeamID = _context.Teams.FirstOrDefault(x => x.FbRefID.Equals(teamFbRefId)).ID;
//            }

//            //await _context.SaveChangesAsync();

//            return Ok();
//        }

//        public async Task<IActionResult> ExecuteBatchImport(int batchId)
//        {
//            var batch = await _context.ScrapeBatches
//                .Include(x => x.ScrapeBatchJobs)
//                .ThenInclude(x => x.Import)
//                .FirstOrDefaultAsync(x => x.ID == batchId);

//            foreach (var job in batch.ScrapeBatchJobs.Where(x => x.ImportID != null))
//            {
//                try
//                {
//                    await ExecuteImport(job.ImportID.Value);
//                    job.Import.Success = true;
//                }
//                catch (Exception e)
//                {
//                    job.Import.Success = true;
//                    job.Import.ErrorMessage = e.InnerException.Message;
//                }

//                await _context.SaveChangesAsync();
//            }

//            return Ok();
//        }

//        public async Task<IActionResult> ExecuteImportAll()
//        {
//            var imports = await _context.MatchLogImports
//                .Where(x => x.Executed == false)
//                .ToListAsync();

//            foreach (var import in imports)
//            {
//                try
//                {
//                    await ExecuteImport(import.ID);
//                    import.Success = true;
//                }
//                catch (Exception e)
//                {
//                    import.Success = true;
//                    import.ErrorMessage = e.InnerException.Message;
//                }

//                await _context.SaveChangesAsync();
//            }

//            return Ok();
//        }

//        private async Task<Matches> GetMatch(List<string> csvLine, string season)
//        {
//            Teams teamOne, teamTwo;

//            if (csvLine[4].Equals("Away"))
//            {
//                teamTwo = _context.Teams.FirstOrDefaultAsync(x => x.FbRefID.Equals(csvLine[6])).Result;

//                //if (teamTwo == null)
//                //{
//                //    var rawTeam = teamDetails.FirstOrDefault(x => x[0].Contains(raw[6]));
//                //    teamTwo = AddNewTeam(raw[6], raw[2]);
//                //}

//                teamOne = _context.Teams.FirstOrDefaultAsync(x => x.FbRefID.Equals(csvLine[7])).Result;

//                //if (teamOne == null)
//                //{
//                //    var rawTeam = teamDetails.FirstOrDefault(x => x[0].Contains(raw[7]));
//                //    teamOne = AddNewTeam(raw[7], raw[2]);
//                //}
//            }
//            else
//            {
//                teamOne = _context.Teams.FirstOrDefaultAsync(x => x.FbRefID.Equals(csvLine[6])).Result;

//                //if (teamOne == null)
//                //{
//                //    var rawTeam = teamDetails.FirstOrDefault(x => x[0].Contains(raw[6]));
//                //    teamOne = AddNewTeam(raw[6], raw[2]);
//                //}

//                teamTwo = _context.Teams.FirstOrDefaultAsync(x => x.FbRefID.Equals(csvLine[7])).Result;

//                //if (teamTwo == null)
//                //{
//                //    var rawTeam = teamDetails.FirstOrDefault(x => x[0].Contains(raw[7]));
//                //    teamTwo = AddNewTeam(raw[7], raw[2]);
//                //}
//            }

//            //await _context.SaveChangesAsync();

//            var teamIds = new int[2] { teamOne.ID, teamTwo.ID };
//            var date = new DateTime(Convert.ToInt32(csvLine[0].Split("-")[0]), Convert.ToInt32(csvLine[0].Split("-")[1]), Convert.ToInt32(csvLine[0].Split("-")[2]));

//            Matches match = _context.Matches.FirstOrDefaultAsync(x =>
//                                teamIds.Contains(x.TeamOneID) && teamIds.Contains(x.TeamTwoID)
//                                && x.Date == date).Result;

//            if (match == null)
//            {
//                match = new Matches()
//                {
//                    Season = season,
//                    Date = new DateTime(ToInteger(csvLine[0].Split("-")[0]), ToInteger(csvLine[0].Split("-")[1]), ToInteger(csvLine[0].Split("-")[2])),
//                    CompetitionID = _context.Competitions.FirstOrDefaultAsync(x => x.Name.Equals(csvLine[2])).Result.ID,
//                    TeamOneID = teamOne.ID,
//                    TeamTwoID = teamTwo.ID,
//                    Round = csvLine[3]
//                };

//                var scores = csvLine[5].Remove(0, 2).Split('-');

//                if (csvLine[4].Equals("Home"))
//                {
//                    match.HomeTeamID = teamOne.ID;
//                    match.TeamOneGoals = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[0]);
//                    match.TeamTwoGoals = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[0]);

//                    if (csvLine[5].Contains("("))
//                    {
//                        match.Penalties = true;
//                        match.TeamOnePenalties = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                        match.TeamTwoPenalties = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                    }
//                }
//                else if (csvLine[4].Equals("Away"))
//                {
//                    match.HomeTeamID = teamOne.ID;
//                    match.TeamTwoGoals = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[0]);
//                    match.TeamOneGoals = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[0]);

//                    if (csvLine[5].Contains("("))
//                    {
//                        match.Penalties = true;
//                        match.TeamTwoPenalties = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                        match.TeamOnePenalties = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                    }
//                }
//                else
//                {
//                    match.IsNeutralVenue = true;
//                    match.TeamOneGoals = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[0]);
//                    match.TeamTwoGoals = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[0]);

//                    if (csvLine[5].Contains("("))
//                    {
//                        match.Penalties = true;
//                        match.TeamOnePenalties = ToInteger(scores[0].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                        match.TeamTwoPenalties = ToInteger(scores[1].Replace("(", "").Replace(")", "").Split(" ")[1]);
//                    }
//                }

//                if (match.Penalties)
//                {
//                    if (match.TeamOnePenalties > match.TeamTwoPenalties)
//                        match.WinningTeamID = teamOne.ID;
//                    else
//                        match.WinningTeamID = teamTwo.ID;
//                }
//                else
//                {
//                    if (match.TeamOneGoals > match.TeamTwoGoals)
//                        match.WinningTeamID = teamOne.ID;
//                    else if (match.TeamTwoGoals > match.TeamOneGoals)
//                        match.WinningTeamID = teamTwo.ID;
//                }

//                _context.Matches.Add(match);
//                //await _context.SaveChangesAsync();
//            }

//            return match;
//        }

//        //private static Teams AddNewTeam(string fbRefID, string competition)
//        //{
//        //    var newTeam = new Teams();
//        //    newTeam.Name = teamDetails.FirstOrDefault(x => x[0].Contains(fbRefID))[1];
//        //    newTeam.FbRefId = fbRefID;
//        //    var competitionTypeId = _context.Competitions.FirstOrDefaultAsync(x => competition.Contains(x.Name)).Result.CompetitionTypeId;
//        //    var clubCompetitions = new List<int>() { 1, 2, 3, 4, 8 };
//        //    var internationalCompetitions = new List<int>() { 5, 6, 9 };

//        //    if (clubCompetitions.Contains(competitionTypeId.Value))
//        //        newTeam.TeamTypeId = (int)TeamType.Club;
//        //    else if (internationalCompetitions.Contains(competitionTypeId.Value))
//        //        newTeam.TeamTypeId = (int)TeamType.International;
//        //    else if (competitionTypeId.Value == 7)
//        //        newTeam.TeamTypeId = (int)TeamType.Youth;

//        //    _context.Teams.Add(newTeam);

//        //    return newTeam;
//        //}

//        #region Helper Methods
//        // Converts unicode to characters
//        private static string ConvertUnicode(string input)
//        {
//            input = input.Replace("\\x20", " ");
//            input = input.Replace("\\x2D", "-");
//            input = input.Replace("\\u00C0", "À");
//            input = input.Replace("\\u00C1", "Á");
//            input = input.Replace("\\u00C2", "Â");
//            input = input.Replace("\\u00C3", "Ã");
//            input = input.Replace("\\u00C4", "Ä");
//            input = input.Replace("\\u00C5", "Å");
//            input = input.Replace("\\u00C6", "Æ");
//            input = input.Replace("\\u00C7", "Ç");
//            input = input.Replace("\\u00C8", "È");
//            input = input.Replace("\\u00C9", "É");
//            input = input.Replace("\\u00CA", "Ê");
//            input = input.Replace("\\u00CB", "Ë");
//            input = input.Replace("\\u00CC", "Ì");
//            input = input.Replace("\\u00CD", "Í");
//            input = input.Replace("\\u00CE", "Î");
//            input = input.Replace("\\u00CF", "Ï");
//            input = input.Replace("\\u00D1", "Ñ");
//            input = input.Replace("\\u00D2", "Ò");
//            input = input.Replace("\\u00D3", "Ó");
//            input = input.Replace("\\u00D4", "Ô");
//            input = input.Replace("\\u00D5", "Õ");
//            input = input.Replace("\\u00D6", "Ö");
//            input = input.Replace("\\u00D8", "Ø");
//            input = input.Replace("\\u00D9", "Ù");
//            input = input.Replace("\\u00DA", "Ú");
//            input = input.Replace("\\u00DB", "Û");
//            input = input.Replace("\\u00DC", "Ü");
//            input = input.Replace("\\u00DD", "Ý");

//            input = input.Replace("\\u00DF", "ß");
//            input = input.Replace("\\u00E0", "à");
//            input = input.Replace("\\u00E1", "á");
//            input = input.Replace("\\u00E2", "â");
//            input = input.Replace("\\u00E3", "ã");
//            input = input.Replace("\\u00E4", "ä");
//            input = input.Replace("\\u00E5", "å");
//            input = input.Replace("\\u00E6", "æ");
//            input = input.Replace("\\u00E7", "ç");
//            input = input.Replace("\\u00E8", "è");
//            input = input.Replace("\\u00E9", "é");
//            input = input.Replace("\\u00EA", "ê");
//            input = input.Replace("\\u00EB", "ë");
//            input = input.Replace("\\u00EC", "ì");
//            input = input.Replace("\\u00ED", "í");
//            input = input.Replace("\\u00EE", "î");
//            input = input.Replace("\\u00EF", "ï");
//            input = input.Replace("\\u00F0", "ð");
//            input = input.Replace("\\u00F1", "ñ");
//            input = input.Replace("\\u00F2", "ò");
//            input = input.Replace("\\u00F3", "ó");
//            input = input.Replace("\\u00F4", "ô");
//            input = input.Replace("\\u00F5", "õ");
//            input = input.Replace("\\u00F6", "ö");
//            input = input.Replace("\\u00F8", "ø");
//            input = input.Replace("\\u00F9", "ù");
//            input = input.Replace("\\u00FA", "ú");
//            input = input.Replace("\\u00FB", "û");
//            input = input.Replace("\\u00FC", "ü");
//            input = input.Replace("\\u00FD", "ý");
//            input = input.Replace("\\u00FF", "ÿ");

//            return input;
//        }

//        // Converts short month string to number
//        private static string MonthTextToNumber(string month)
//        {
//            switch (month.ToLower())
//            {
//                case "jan":
//                    return "01";
//                case "january":
//                    return "01";
//                case "feb":
//                    return "02";
//                case "february":
//                    return "02";
//                case "mar":
//                    return "03";
//                case "march":
//                    return "03";
//                case "apr":
//                    return "04";
//                case "april":
//                    return "04";
//                case "may":
//                    return "05";
//                case "jun":
//                    return "06";
//                case "june":
//                    return "06";
//                case "jul":
//                    return "07";
//                case "july":
//                    return "07";
//                case "aug":
//                    return "08";
//                case "august":
//                    return "08";
//                case "sep":
//                    return "09";
//                case "september":
//                    return "09";
//                case "oct":
//                    return "10";
//                case "october":
//                    return "10";
//                case "nov":
//                    return "11";
//                case "november":
//                    return "11";
//                case "dec":
//                    return "12";
//                case "december":
//                    return "12";
//                default:
//                    return "";
//            }
//        }

//        // Converts number summary string to decimal eg. 3.6m to 3600000
//        private static decimal? MoneyStringToDecimal(string amount)
//        {
//            if (amount.Contains("Th."))
//                return Convert.ToDecimal(amount.Replace("Th.", "")) * 1000;
//            else if (amount.Contains("m"))
//                return Convert.ToDecimal(amount.Replace("m", "")) * 1000000;

//            return null;
//        }

//        // Converts string to Integer
//        private static int ToInteger(string text)
//        {
//            if (String.IsNullOrWhiteSpace(text))
//                text = "0";
//            return Int32.Parse(text);
//        }

//        private static decimal ToDecimal(string text)
//        {
//            if (String.IsNullOrWhiteSpace(text) || text.Equals("0.0") || text.Equals("0.00"))
//                text = "0";
//            return Convert.ToDecimal(text);
//        }

//        private decimal CalculatePercentage(string numerator, string denominator)
//        {
//            return CalculatePercentage(ToDecimal(numerator), ToInteger(denominator));
//        }

//        // Calculates the percentage for an integer numerator
//        private decimal CalculatePercentage(int numerator, int denominator)
//        {
//            return CalculatePercentage((decimal)numerator, denominator);
//        }

//        // Calculates the percentage for a decimal numerator
//        private decimal CalculatePercentage(decimal numerator, int denominator)
//        {
//            if ((numerator == 0 && denominator == 0) || denominator == 0)
//                return 0;

//            return (numerator / denominator) * 100;
//        }

//        private decimal Divide(string numeratorStr, string denominatorStr)
//        {
//            var numerator = ToDecimal(numeratorStr);
//            var denominator = ToInteger(denominatorStr);

//            if (denominator == 0)
//                return 0;
//            return Divide(numerator, denominator);
//        }

//        private decimal Divide(int numerator, int denominator)
//        {
//            if (denominator == 0)
//                return 0;
//            return Divide((decimal)numerator, denominator);
//        }

//        private decimal Divide(decimal numerator, int denominator)
//        {
//            if ((numerator == 0 && denominator == 0) || denominator == 0)
//                return 0;

//            return numerator / denominator;
//        }

//        // Populates select lists used on Scrape/New view
//        private void PopulateSelectLists(ScrapeDetailsVM vm)
//        {
//            vm.PlayerSelectList = _context.Players
//                .OrderBy(x => x.Name)
//                .Select(x => new SelectListItem()
//                {
//                    Value = x.ID.ToString(),
//                    Text = x.Name
//                })
//                .ToList();

//            vm.SeasonSelectList = _context.Seasons
//                .OrderByDescending(x => Convert.ToInt32(x.Year.Substring(0, 4)))
//                .Select(x => new SelectListItem()
//                {
//                    Text = x.Year
//                })
//                .ToList();

//            vm.TeamSelectList = _context.Teams
//                .OrderBy(x => x.Name)
//                .Select(x => new SelectListItem()
//                {
//                    Value = x.FbRefID,
//                    Text = x.Name
//                })
//                .ToList();
//        }

//        // Converts position name to short code if needed - and returns position id from database
//        private int GetPositionID(string position)
//        {
//            if (position.Equals("Goalkeeper"))
//            {
//                position = "GK";
//            }
//            else if (position.Equals("Left-Back"))
//            {
//                position = "LB";
//            }
//            else if (position.Equals("Right-Back"))
//            {
//                position = "RB";
//            }
//            else if (position.Equals("Centre-Back") || position.Equals("Sweeper"))
//            {
//                position = "CB";
//            }
//            else if (position.Equals("Defensive Midfield"))
//            {
//                position = "DM";
//            }
//            else if (position.Equals("Central Midfield"))
//            {
//                position = "CM";
//            }
//            else if (position.Equals("Right Midfield"))
//            {
//                position = "RM";
//            }
//            else if (position.Equals("Left Midfield"))
//            {
//                position = "LM";
//            }
//            else if (position.Equals("Left Winger"))
//            {
//                position = "LW";
//            }
//            else if (position.Equals("Right Winger"))
//            {
//                position = "RW";
//            }
//            else if (position.Equals("Attacking Midfield"))
//            {
//                position = "AM";
//            }
//            else if (position.Equals("Centre-Forward") || position.Equals("Second Striker"))
//            {
//                position = "FW";
//            }

//            return _context.Positions.FirstOrDefault(x => x.Code.Equals(position)).ID;
//        }
//        #endregion
//    }
//}
