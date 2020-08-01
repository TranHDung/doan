using Common.DataAccess.EFCore.Configuration;
using Common.DataAccess.EFCore.Configuration.System;
using Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Common.DataAccess.EFCore
{
    public class DataContext : DbContext
    {
        public ContextSession Session { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Respond> Responds { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<GameShow> GameShows { get; set; }
        public DbSet<QuestionGameShow> QuestionGameShows { get; set; }
        public DbSet<UserGameShow> UserGameShows { get; set; }
        public DataContext() { 
        
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Common.WebApiCore"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();
            var connectionString = configuration.GetConnectionString("localDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserClaimConfig());
            modelBuilder.ApplyConfiguration(new UserPhotoConfig());
            modelBuilder.ApplyConfiguration(new SettingsConfig());

            modelBuilder.HasDefaultSchema("project");
            modelBuilder.Entity<Question>().HasKey(q => q.Id);

            modelBuilder.Entity<QuestionGameShow>()
           .HasOne(pt => pt.Question)
           .WithMany(p => p.QuestionGameShows)
           .HasForeignKey(pt => pt.QuestionId);

            modelBuilder.Entity<QuestionGameShow>()
                .HasOne(pt => pt.GameShow)
                .WithMany(t => t.QuestionGameShows)
                .HasForeignKey(pt => pt.GameshowId);

            modelBuilder.Entity<UserGameShow>()
           .HasOne(pt => pt.User)
           .WithMany(p => p.UserGameShows)
           .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserGameShow>()
                .HasOne(pt => pt.GameShow)
                .WithMany(t => t.UserGameShows)
                .HasForeignKey(pt => pt.GameshowId);
        }
    }
}
