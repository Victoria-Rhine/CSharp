/* Auto generated SportsContext */

namespace SportsSite.Models.DAL
{
    using System.Data.Entity;

    public partial class SportsContext : DbContext
    {
        public SportsContext()
            : base("name=SportsContext_Azure")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<LocationDetail> LocationDetails { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athlete>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Athlete)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Coach)
                .HasForeignKey(e => e.CID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Event)
                .HasForeignKey(e => e.EID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LocationDetail>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.LocationDetail)
                .HasForeignKey(e => e.LID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Athletes)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);
        }
    }
}
