using AkriStat.Constants;
using AkriStat.Models;
using System;
using System.Linq;

namespace AkriStat.Helpers
{
    public static class UserHelper
    {
        public static bool UserIsStaff(this AspNetUsers user)
        {
            return UserRoles.StaffRoles.Any(x => x.Equals(user.GetRoleId()));
        }

        public static bool WorksForTeam(this AspNetUsers user)
        {
            return user.UserIsStaff() && user.AspNetUserRoles.First().AspNetUserRoleTeams.Count > 0;
        }

        public static bool IsAdmin(this AspNetUsers user)
        {
            return user.GetRoleId().Equals(UserRoles.AdministratorId);
        }

        public static bool IsStandardUser(this AspNetUsers user)
        {
            return user.GetRoleId().Equals(UserRoles.StandardUserId);
        }

        public static Guid GetRoleId(this AspNetUsers user)
        {
            return new Guid(user.AspNetUserRoles.First().RoleId);
        }
    }
}