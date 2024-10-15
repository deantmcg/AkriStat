using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AkriStat.Models
{
    public partial class AkriStatDbContext : DbContext
    {
        public AkriStatDbContext()
        {
        }

        public AkriStatDbContext(DbContextOptions<AkriStatDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoleTeams> AspNetUserRoleTeams { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CompetitionSeasonTeams> CompetitionSeasonTeams { get; set; }
        public virtual DbSet<CompetitionTypes> CompetitionTypes { get; set; }
        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<LeagueTableLines> LeagueTableLines { get; set; }
        public virtual DbSet<MatchLogImportFiles> MatchLogImportFiles { get; set; }
        public virtual DbSet<MatchLogImports> MatchLogImports { get; set; }
        public virtual DbSet<MatchTeamStats> MatchTeamStats { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<PlayerMatchLogSummaries> PlayerMatchLogSummaries { get; set; }
        public virtual DbSet<PlayerMatchLogs> PlayerMatchLogs { get; set; }
        public virtual DbSet<PlayerTeamsHistory> PlayerTeamsHistory { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<ScrapeBatchJobs> ScrapeBatchJobs { get; set; }
        public virtual DbSet<ScrapeBatches> ScrapeBatches { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<ShortlistedPlayers> ShortlistedPlayers { get; set; }
        public virtual DbSet<Shortlists> Shortlists { get; set; }
        public virtual DbSet<TeamMatchLogSummaries> TeamMatchLogSummaries { get; set; }
        public virtual DbSet<TeamTypes> TeamTypes { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<vwCombinedMatchLogs> vwCombinedMatchLogs { get; set; }
        public virtual DbSet<vwLeagueTable> vwLeagueTable { get; set; }
        public virtual DbSet<vwMatchTeamStats> vwMatchTeamStats { get; set; }
        public virtual DbSet<vwPlayerCarries> vwPlayerCarries { get; set; }
        public virtual DbSet<vwPlayerMatchLogSummaries> vwPlayerMatchLogSummaries { get; set; }
        public virtual DbSet<vwSummariesAdvancedSearch> vwSummariesAdvancedSearch { get; set; }
        public virtual DbSet<vwSummaryAttackingMidAndWingers> vwSummaryAttackingMidAndWingers { get; set; }
        public virtual DbSet<vwSummaryCentreBacks> vwSummaryCentreBacks { get; set; }
        public virtual DbSet<vwSummaryCentreMidfielders> vwSummaryCentreMidfielders { get; set; }
        public virtual DbSet<vwSummaryFullBacks> vwSummaryFullBacks { get; set; }
        public virtual DbSet<vwSummaryKeepers> vwSummaryKeepers { get; set; }
        public virtual DbSet<vwSummaryStriker> vwSummaryStriker { get; set; }
        public virtual DbSet<vwSummaryTeamAttacking> vwSummaryTeamAttacking { get; set; }
        public virtual DbSet<vwSummaryTeamDefensive> vwSummaryTeamDefensive { get; set; }
        public virtual DbSet<vwTeamMatchLogSummaries> vwTeamMatchLogSummaries { get; set; }
        public virtual DbSet<vwTeamMatchSummaries> vwTeamMatchSummaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:akristat.database.windows.net,1433;Initial Catalog=AkriStat;Persist Security Info=False;User ID=ASDBAdmin;Password=$&4T+rh$H6QaTh=m;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoleTeams>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId, e.TeamId });

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.AspNetUserRoleTeams)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__AspNetUse__TeamI__5D4BCC77");

                entity.HasOne(d => d.AspNetUserRoles)
                    .WithMany(p => p.AspNetUserRoleTeams)
                    .HasForeignKey(d => new { d.UserId, d.RoleId })
                    .HasConstraintName("FK_AspNetUserRoleTeams");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CompetitionSeasonTeams>(entity =>
            {
                entity.HasKey(e => new { e.SeasonYear, e.CompetitionID, e.TeamID })
                    .HasName("PK__Competit__DBF6FC97B8901C90");

                entity.Property(e => e.SeasonYear).HasMaxLength(20);

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionSeasonTeams)
                    .HasForeignKey(d => d.CompetitionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competiti__Compe__7A672E12");

                entity.HasOne(d => d.SeasonYearNavigation)
                    .WithMany(p => p.CompetitionSeasonTeams)
                    .HasForeignKey(d => d.SeasonYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competiti__Seaso__7B5B524B");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitionSeasonTeams)
                    .HasForeignKey(d => d.TeamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competiti__TeamI__7C4F7684");
            });

            modelBuilder.Entity<CompetitionTypes>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Competitions>(entity =>
            {
                entity.Property(e => e.FbRefID)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.CompetitionType)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.CompetitionTypeID)
                    .HasConstraintName("FK__Competiti__Compe__0A9D95DB");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.NationID)
                    .HasConstraintName("FK__Competiti__Natio__0B91BA14");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.FlagUrl).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<LeagueTableLines>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Name).HasMaxLength(80);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<MatchLogImportFiles>(entity =>
            {
                entity.HasKey(e => e.ImportID)
                    .HasName("PK__MatchLog__8697678A6C7DB7AA");

                entity.Property(e => e.ImportID).ValueGeneratedNever();

                entity.Property(e => e.Bytes).IsRequired();

                entity.HasOne(d => d.Import)
                    .WithOne(p => p.MatchLogImportFiles)
                    .HasForeignKey<MatchLogImportFiles>(d => d.ImportID)
                    .HasConstraintName("FK__MatchLogI__Impor__5C8CB268");
            });

            modelBuilder.Entity<MatchLogImports>(entity =>
            {
                entity.Property(e => e.DateExecuted).HasColumnType("date");

                entity.Property(e => e.DateScraped)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.MatchLogImports)
                    .HasForeignKey(d => d.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchLogI__Playe__30AE302A");
            });

            modelBuilder.Entity<MatchTeamStats>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TeamOneGkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneName).HasMaxLength(80);

                entity.Property(e => e.TeamOneNonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneNonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneXGAssisted).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoGkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoName).HasMaxLength(80);

                entity.Property(e => e.TeamTwoNonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoNonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoXGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.CompetitionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__Competi__00200768");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchesHomeTeam)
                    .HasForeignKey(d => d.HomeTeamID)
                    .HasConstraintName("FK__Matches__HomeTea__02FC7413");

                entity.HasOne(d => d.SeasonNavigation)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.Season)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__Season__047AA831");

                entity.HasOne(d => d.TeamOne)
                    .WithMany(p => p.MatchesTeamOne)
                    .HasForeignKey(d => d.TeamOneID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__TeamOne__01142BA1");

                entity.HasOne(d => d.TeamTwo)
                    .WithMany(p => p.MatchesTeamTwo)
                    .HasForeignKey(d => d.TeamTwoID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Matches__TeamTwo__02084FDA");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.MatchesWinningTeam)
                    .HasForeignKey(d => d.WinningTeamID)
                    .HasConstraintName("FK__Matches__Winning__03F0984C");
            });

            modelBuilder.Entity<PlayerMatchLogSummaries>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AverageAerialDualsWonPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageDribblersTackledPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageLongPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageMediumPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesReceivedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageProgressivePassesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShortPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShotsOnTargetPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulDribblesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulPressuresPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageCrossesStoppedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesAttemptedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesCompletedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageSavesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Position).HasMaxLength(4);

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<PlayerMatchLogs>(entity =>
            {
                entity.Property(e => e.AerialDualsWonPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DribblersTackledPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkAverageYardsPassLength)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkCleanSheet).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkCrossesStopped).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkCrossesStoppedPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkDefensiveActionsOutsidePenaltyArea).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkGoalKickAverageYards)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkGoalKicksAttempted).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkGoalKicksLaunchedPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkGoalsConceded).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkOpponentCrossesAttempted).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPassesAttempted).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPassesAttemptedOver40Yards).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPassesCompletedOver40Yards).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPassesCompletedOver40YardsPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPassesOver40YardsPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPenaltiesConceded).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPenaltiesFaced).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPenaltiesFacedMissed).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPenaltiesSaved).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkPostShotXG)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkSaves).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkSavesPercentage)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GkShotsOnTargetFaced).HasDefaultValueSql("((0))");

                entity.Property(e => e.GkThrowsAttempted).HasDefaultValueSql("((0))");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GoalsPerShot).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GoalsPerShotOnTarget).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LongPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MediumPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyXgPerShot).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PassesReceivedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PositionPlayed).HasMaxLength(20);

                entity.Property(e => e.ProgressivePassesPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ShortPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ShotsOnTargetPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SuccessfulDribblesPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SuccessfulPressuresPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.XG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerMatchLogs)
                    .HasForeignKey(d => d.MatchID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Match__67DE6983");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerMatchLogs)
                    .HasForeignKey(d => d.PlayerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__Playe__68D28DBC");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlayerMatchLogs)
                    .HasForeignKey(d => d.TeamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerMat__TeamI__69C6B1F5");
            });

            modelBuilder.Entity<PlayerTeamsHistory>(entity =>
            {
                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.DateLeft).HasColumnType("date");

                entity.HasOne(d => d.ParentClubNavigation)
                    .WithMany(p => p.PlayerTeamsHistoryParentClubNavigation)
                    .HasForeignKey(d => d.ParentClub)
                    .HasConstraintName("FK__PlayerTea__Paren__7D63964E");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlayerTeamsHistoryTeam)
                    .HasForeignKey(d => d.TeamID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerTea__TeamI__7C6F7215");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.ContractExpiry).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FacePictureUrl).HasMaxLength(300);

                entity.Property(e => e.FacebookUrl).HasMaxLength(300);

                entity.Property(e => e.FbRefID)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Footed).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstagramUrl).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NormalizedFullName).HasMaxLength(300);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(80);

                entity.Property(e => e.TransfermarktID)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TwitterUrl).HasMaxLength(300);

                entity.Property(e => e.Value).HasColumnType("money");

                entity.Property(e => e.WeeklyWage).HasColumnType("money");

                entity.HasOne(d => d.CurrentTeam)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurrentTeamID)
                    .HasConstraintName("FK__Players__Current__10766AC2");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.PlayersNationality)
                    .HasForeignKey(d => d.NationalityID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Players__Nationa__73BA3083");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Players__Positio__7993056A");

                entity.HasOne(d => d.SecondNationality)
                    .WithMany(p => p.PlayersSecondNationality)
                    .HasForeignKey(d => d.SecondNationalityID)
                    .HasConstraintName("FK__Players__SecondN__74AE54BC");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(4);

                entity.Property(e => e.ColourCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ScrapeBatchJobs>(entity =>
            {
                entity.Property(e => e.ErrorMessage).HasMaxLength(1000);

                entity.Property(e => e.QueryFbRefID).HasMaxLength(200);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.ScrapeBatchJobs)
                    .HasForeignKey(d => d.ImportID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ScrapeBat__Impor__0682EC34");

                entity.HasOne(d => d.QueryPlayer)
                    .WithMany(p => p.ScrapeBatchJobs)
                    .HasForeignKey(d => d.QueryPlayerID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ScrapeBat__Query__058EC7FB");

                entity.HasOne(d => d.ScrapeBatch)
                    .WithMany(p => p.ScrapeBatchJobs)
                    .HasForeignKey(d => d.ScrapeBatchID)
                    .HasConstraintName("FK__ScrapeBat__Scrap__049AA3C2");

                entity.HasOne(d => d.SeasonNavigation)
                    .WithMany(p => p.ScrapeBatchJobs)
                    .HasForeignKey(d => d.Season)
                    .HasConstraintName("FK__ScrapeBat__Seaso__0777106D");
            });

            modelBuilder.Entity<ScrapeBatches>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ScrapeBatches)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScrapeBat__Creat__62458BBE");
            });

            modelBuilder.Entity<Seasons>(entity =>
            {
                entity.HasKey(e => e.Year)
                    .HasName("PK__Seasons__D4BD6055C91300B3");

                entity.Property(e => e.Year).HasMaxLength(20);
            });

            modelBuilder.Entity<ShortlistedPlayers>(entity =>
            {
                entity.HasKey(e => new { e.ShortlistID, e.PlayerID })
                    .HasName("PK__Shortlis__C1A8EA3AB7C84604");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.ShortlistedPlayers)
                    .HasForeignKey(d => d.PlayerID)
                    .HasConstraintName("FK__Shortlist__Playe__60924D76");

                entity.HasOne(d => d.Shortlist)
                    .WithMany(p => p.ShortlistedPlayers)
                    .HasForeignKey(d => d.ShortlistID)
                    .HasConstraintName("FK__Shortlist__Short__5F9E293D");
            });

            modelBuilder.Entity<Shortlists>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserID)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shortlists)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK__Shortlist__UserI__5CC1BC92");
            });

            modelBuilder.Entity<TeamMatchLogSummaries>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AverageAerialDualsWonPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageDribblersTackledPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageLongPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageMediumPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesReceivedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageProgressivePassesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShortPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShotsOnTargetPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulDribblesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulPressuresPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageCrossesStoppedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesAttemptedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesCompletedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageSavesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.TeamName).HasMaxLength(80);

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<TeamTypes>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.ColourCode1).HasMaxLength(10);

                entity.Property(e => e.ColourCode2).HasMaxLength(10);

                entity.Property(e => e.ColourCode3).HasMaxLength(10);

                entity.Property(e => e.FbRefID)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.NormalizedFullName).HasMaxLength(300);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.StadiumName).HasMaxLength(200);

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.NationID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teams__NationID__70DDC3D8");

                entity.HasOne(d => d.TeamType)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teams__TeamTypeI__0F624AF8");
            });

            modelBuilder.Entity<vwCombinedMatchLogs>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCombinedMatchLogs");

                entity.Property(e => e.AerialDualsWonPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CompetitionName).HasMaxLength(150);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DribblersTackledPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkCrossesStoppedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkGoalKicksLaunchedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkPassesCompletedOver40YardsPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkPassesOver40YardsPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GkSavesPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GoalsPerShot).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.GoalsPerShotOnTarget).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LongPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.MediumPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NonPenaltyXgPerShot).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PassesReceivedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PositionPlayed).HasMaxLength(20);

                entity.Property(e => e.ProgressivePassesPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Round).HasMaxLength(100);

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.ShortPassesCompletedPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ShotsOnTargetPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SuccessfulDribblesPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SuccessfulPressuresPercentage).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TeamOneName).HasMaxLength(80);

                entity.Property(e => e.TeamTwoName).HasMaxLength(80);

                entity.Property(e => e.XG).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<vwLeagueTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwLeagueTable");

                entity.Property(e => e.Name).HasMaxLength(80);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwMatchTeamStats>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMatchTeamStats");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TeamOneGkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneName).HasMaxLength(80);

                entity.Property(e => e.TeamOneNonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneNonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamOneXGAssisted).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoGkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoName).HasMaxLength(80);

                entity.Property(e => e.TeamTwoNonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoNonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.TeamTwoXGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<vwPlayerCarries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPlayerCarries");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwPlayerMatchLogSummaries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPlayerMatchLogSummaries");

                entity.Property(e => e.AverageAerialDualsWonPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageDribblersTackledPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageLongPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageMediumPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesReceivedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageProgressivePassesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShortPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShotsOnTargetPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulDribblesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulPressuresPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageCrossesStoppedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesAttemptedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesCompletedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageSavesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Position).HasMaxLength(4);

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<vwSummariesAdvancedSearch>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummariesAdvancedSearch");

                entity.Property(e => e.AverageAerialDualsWonPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageDribblersTackledPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageLongPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageMediumPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesReceivedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageProgressivePassesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShortPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShotsOnTargetPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulDribblesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulPressuresPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.ContractExpiry).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FacePictureUrl).HasMaxLength(300);

                entity.Property(e => e.Footed).HasMaxLength(100);

                entity.Property(e => e.GkAverageCrossesStoppedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesAttemptedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesCompletedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageSavesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NationalityFlagUrl).HasMaxLength(300);

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NormalizedFullName).HasMaxLength(300);

                entity.Property(e => e.NormalizedPlayerName).HasMaxLength(150);

                entity.Property(e => e.Position).HasMaxLength(4);

                entity.Property(e => e.PositionDisplay).HasMaxLength(60);

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.SecondNationalityFlagUrl).HasMaxLength(300);

                entity.Property(e => e.Value).HasColumnType("money");

                entity.Property(e => e.WeeklyWage).HasColumnType("money");

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<vwSummaryAttackingMidAndWingers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryAttackingMidAndWingers");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryCentreBacks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryCentreBacks");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryCentreMidfielders>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryCentreMidfielders");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryFullBacks>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryFullBacks");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryKeepers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryKeepers");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryStriker>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryStriker");

                entity.Property(e => e.PlayerName).HasMaxLength(150);

                entity.Property(e => e.Season).HasMaxLength(20);
            });

            modelBuilder.Entity<vwSummaryTeamAttacking>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryTeamAttacking");

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.TeamName).HasMaxLength(80);
            });

            modelBuilder.Entity<vwSummaryTeamDefensive>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSummaryTeamDefensive");

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.TeamName).HasMaxLength(80);
            });

            modelBuilder.Entity<vwTeamMatchLogSummaries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTeamMatchLogSummaries");

                entity.Property(e => e.AverageAerialDualsWonPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageDribblersTackledPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageLongPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageMediumPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AveragePassesReceivedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageProgressivePassesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShortPassesCompletedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageShotsOnTargetPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulDribblesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.AverageSuccessfulPressuresPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageCrossesStoppedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageDistanceFromGoalForDefensiveActions).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageGoalKicksLaunchedPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesAttemptedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAveragePassesCompletedOver40YardsPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageSavesPercentage).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkAverageYardsPassLength).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkGoalKickAverageYards).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.TeamName).HasMaxLength(80);

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            modelBuilder.Entity<vwTeamMatchSummaries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwTeamMatchSummaries");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GkPostShotXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.GoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyGoalsMinusXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.NonPenaltyXG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.OpponentName).HasMaxLength(80);

                entity.Property(e => e.Round).HasMaxLength(100);

                entity.Property(e => e.Season).HasMaxLength(20);

                entity.Property(e => e.TeamName).HasMaxLength(80);

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.XG).HasColumnType("decimal(38, 4)");

                entity.Property(e => e.XGAssisted).HasColumnType("decimal(38, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
