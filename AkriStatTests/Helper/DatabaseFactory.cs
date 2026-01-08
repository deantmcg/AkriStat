using AkriStat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AkriStatTests.Helper
{
    class DatabaseFactory
    {
        public async Task<AkriStatDbContext> CreateDatabase()
        {
            var options = new DbContextOptionsBuilder<AkriStatDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new AkriStatDbContext(options);
            context.Database.EnsureCreated();

            var positions = new string[] { "GK", "CB", "RB", "LB", "DM", "CM", "RM", "LM", "AM", "RW", "LW", "FW" };

            for (int i = 0; i < positions.Length; i++)
            {
                context.Positions.Add(new Positions()
                {
                    ListOrder = i + 1,
                    Name = positions[i],
                    Code = positions[i],
                    ColourCode = "#000000"
                });

                await context.SaveChangesAsync();
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Countries.Add(new Countries()
                {
                    Name = $"Country {i}",
                    Code = $"C{i}",
                    FlagUrl = ""
                });
                await context.SaveChangesAsync();
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Competitions.Add(new Competitions()
                {
                    Name = $"League {i}",
                    CompetitionTypeID = 1,
                    NationID = 1,
                    FbRefID = $"fbref{i}"
                });
                await context.SaveChangesAsync();
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Teams.Add(new Teams()
                {
                    Name = $"Team {i}",
                    NationID = 1,
                    TeamTypeID = 1,
                    ColourCode1 = "#FFF",
                    ColourCode2 = "#000",
                    FbRefID = $"fbref{i}",
                    NormalizedName = $"team {i}",
                    FullName = $"Team {i}",
                    NormalizedFullName = $"team {i}"
                });
                await context.SaveChangesAsync();
            }

            for (int i = 1; i <= 10; i++)
            {
                context.Players.Add(new Players()
                {
                    Name = $"Player {i}",
                    DateOfBirth = new DateTime(1996, 1, 1),
                    NationalityID = 1,
                    PositionID = 1,
                    FbRefID = $"fbref{i}",
                    NormalizedName = $"player {i}",
                    FullName = $"Player {i}",
                    NormalizedFullName = $"player {i}",
                    TransfermarktID = $"tm{i}"
                });
                await context.SaveChangesAsync();
            }

            return context;
        }
    }
}
