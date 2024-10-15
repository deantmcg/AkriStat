using AkriStat.Constants;
using AkriStat.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkriStatTests.Helper
{
    public class UserFactory
    {
        public async Task<ClaimsPrincipal> CreateUser(string type, string userId, AkriStatDbContext context)
        {
            ClaimsIdentity identity;
            ClaimsPrincipal user;

            if (type.Equals("unauthenticated"))
            {
                identity = new ClaimsIdentity();
            }
            else
            {
                identity = new ClaimsIdentity("Identity.Application");
                identity.AddClaim(new Claim(ASClaimTypes.FavouriteTeam, "1"));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));
                if (type.Equals("admin"))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Test Administrator"));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));
                }
                else if (type.Equals("standard"))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Test Standard User"));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Standard User"));
                }
                else if (type.Equals("chief scout"))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Test Chief Scout"));
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Chief Scout"));
                    context.AspNetUserRoleTeams.Add(new AspNetUserRoleTeams()
                    {
                        UserId = userId,
                        TeamId = 2,
                        RoleId = Guid.NewGuid().ToString()
                    });
                }
                else if (type.Equals("scout") || type.Equals("analyst"))
                {
                    if (type.Equals("scout"))
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, "Test Scout"));
                        identity.AddClaim(new Claim(ClaimTypes.Role, "Scout"));
                    }
                    else
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Name, "Test Analyst"));
                        identity.AddClaim(new Claim(ClaimTypes.Role, "Analyst"));
                    }
                    context.AspNetUserRoleTeams.Add(new AspNetUserRoleTeams()
                    {
                        UserId = userId,
                        TeamId = 2,
                        RoleId = Guid.NewGuid().ToString()
                    });
                }

                for (int i = 1; i < 5; i++)
                {
                    context.Shortlists.Add(new Shortlists()
                    {
                        Name = $"Shortlist {i}",
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        LastUpdatedDate = DateTime.Now,
                        UserID = userId
                    });
                    await context.SaveChangesAsync();
                }
            }

            user = new ClaimsPrincipal(identity);

            return user;
        }
    }
}
