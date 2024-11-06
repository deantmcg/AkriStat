using AkriStat.Models;
using System;
using System.Linq;

namespace AkriStat.Helpers
{
    public static class UserHelper
    {
        private static readonly Guid AdministratorId = new Guid("649FE9C4-A752-486E-9888-77960D50A003");
        private static readonly Guid AnalystId = new Guid("B9D0EA79-74E3-4943-A342-494C61F9945C");
        private static readonly Guid StandardUserId = new Guid("CE19C27E-AF7C-4D26-B7D2-B733595B91A6");
        private static readonly Guid ScoutId = new Guid("D4F6C614-10F3-4A79-924B-0427F0FE46DD");
        private static readonly Guid ChiefScoutId = new Guid("A6EB7353-483D-4191-A561-8EB97E51E64F");

        public static bool UserIsStaff(this AspNetUsers user)
        {
            Guid[] staffRoles = new Guid[] { AnalystId, ScoutId, ChiefScoutId };

            if (staffRoles.Any(x => x.Equals(user.GetRoleId())))
            {
                return true;
            }

            return false;
        }

        public static bool WorksForTeam(this AspNetUsers user)
        {
            var isStaffRole = user.UserIsStaff();

            if (isStaffRole)
            {
                if (user.AspNetUserRoles.First().AspNetUserRoleTeams.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsAdmin(this AspNetUsers user)
        {
            if (user.GetRoleId().Equals(AdministratorId))
            {
                return true;
            }

            return false;
        }

        public static bool IsStandardUser(this AspNetUsers user)
        {
            if (user.GetRoleId().Equals(StandardUserId))
            {
                return true;
            }

            return false;
        }

        public static Guid GetRoleId(this AspNetUsers user)
        {
            return new Guid(user.AspNetUserRoles.First().RoleId);
        }
    }
}