namespace AkriStat.Constants
{
    public class SiteProperties
    {
        public const string CurrentSeason = "2019-20";

        public readonly string[][] Roles =
        {
            new string[] { "649FE9C4-A752-486E-9888-77960D50A003", "Administrator" },
            new string[] { "B9D0EA79-74E3-4943-A342-494C61F9945C", "Analyst" },
            new string[] { "CE19C27E-AF7C-4D26-B7D2-B733595B91A6", "Standard User" },
            new string[] { "D4F6C614-10F3-4A79-924B-0427F0FE46DD", "Scout" },
            new string[] { "D4F6C614-10F3-4A79-924B-0427F0FE46DD", "Chief Scout" }
        };

        public enum Page
        {
            Player,
            Team,
            Shortlist,
            Account
        }
    }
}
