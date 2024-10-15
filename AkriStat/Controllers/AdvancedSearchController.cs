using AkriStat.Models;
using AkriStat.SearchConditions;
using AkriStat.ViewModels.Search;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AkriStat.Controllers
{
    public class AdvancedSearchController : Controller
    {
        private readonly AkriStatDbContext _context;
        private readonly IMapper _mapper;

        public AdvancedSearchController(AkriStatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Returns Advanced Search view
        [HttpGet, Route("AdvancedSearch")]
        public IActionResult GetSearch()
        {
            var vm = new AdvancedSearchContainerVM();
            ViewData["Title"] = "Advanced Search";
            return View("Advanced", new AdvancedSearchContainerVM());
        }

        // Posts search criteria and returns results
        [HttpPost, Route("AdvancedSearch")]
        [ValidateAntiForgeryToken]
        public IActionResult PostSearch(AdvancedSearchContainerVM vm)
        {
            var originalVM = vm; // preserves search criteria

            // Generate SQL command from search criteria
            var query = GenerateQuery(vm);

            // Execute generated SQL command
            var summaries = _context.vwSummariesAdvancedSearch
                .FromSqlRaw(query)
                .ToList();

            originalVM.SearchResults = _mapper.Map<List<AdvancedSearchResultVM>>(summaries);

            ViewData["Title"] = $"Search Results ({summaries.Count()})";
            return View("AdvancedResults", originalVM);
        }

        // Generates and returns SQL query from user advanced search criteria
        private string GenerateQuery(AdvancedSearchContainerVM vm)
        {
            SetMinMaxValues(vm);

            var query = new Query("vwSummariesAdvancedSearch")
                .Where("Season", vm.Season);
            
            // If name entered
            if (!string.IsNullOrWhiteSpace(vm.Name))
                query.WhereContains("Name", vm.Name);

            // If position(s) selected
            if (vm.Position.Count() > 0)
                query.WhereIn("Position", vm.Position);

            // If nationality/nationalities selected
            if (vm.Nationality.Count() > 0)
                query.WhereIn("NationalityID", vm.Nationality);

            // If second nationality/nationalities selected
            if (vm.SecondNationality.Count() > 0)
                query.WhereIn("SecondNationalityID", vm.SecondNationality);

            // All view model properties iterated
            foreach (var property in vm.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                // if property is an int range and not null - add to query
                if (type == typeof(IntRange))
                {
                    dynamic value = property.GetValue(vm, null);
                    IntRange range = value;
                    if (!range.IsNull)
                    {
                        if (property.Name.Equals("Age"))
                        {
                            var dateRange = GenerateAgeRange(range);
                            query.WhereBetween("DateOfBirth", dateRange.Max, dateRange.Min);
                        }
                        else
                        {
                            query.WhereBetween(property.Name, range.Min, range.Max);
                        }
                    }
                }
                // if property is a date range and not null - add to query
                else if (type == typeof(DateRange))
                {
                    dynamic value = property.GetValue(vm, null);
                    DateRange range = value;
                    if (!range.IsNull)
                        query.WhereBetween(property.Name, range.Min.Value.ToString("yyyy-MM-dd"), range.Max.Value.ToString("yyyy-MM-dd"));
                }
            }

            // generates the query string
            var compiler = new SqlServerCompiler();
            var result = compiler.Compile(query);

            return result.ToString();
        }

        /* Converts int date age range to a date time range
           Makes user input easier */
        private DateRange GenerateAgeRange(IntRange intRange)
        {
            var dateRange = new DateRange();

            dateRange.Min = intRange.Min == int.MinValue ? DateTime.MinValue : DateTime.Now.Date.AddYears((intRange.Min.Value) * -1);
            dateRange.Max = intRange.Max == int.MaxValue ? DateTime.MaxValue : DateTime.Now.Date.AddYears((intRange.Max.Value +1) * -1).AddSeconds(-1);

            return dateRange;
        }

        /* Sets the opposite boundary if only one has been set
         * eg. if only upper boundary is specified - set lower to zero */
        private void SetMinMaxValues(AdvancedSearchContainerVM vm)
        {
            foreach (var property in vm.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                if (type == typeof(IntRange))
                {
                    dynamic value = property.GetValue(vm, null);
                    IntRange range = value;
                    range.SetNulls();
                    property.SetValue(vm, range, null);
                }
                else if (type == typeof(DateRange))
                {
                    dynamic value = property.GetValue(vm, null);
                    DateRange range = value;
                    range.SetNulls();
                    property.SetValue(vm, range, null);
                }
            }
        }
    }
}
