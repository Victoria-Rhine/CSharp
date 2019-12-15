using TheFinalBattle.Models;

namespace TheFinalBattle.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinalContext : DbContext
    {

        public FinalContext()
            : base("name=FinalContext_Azure")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<RSVP> RSVPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasMany(e => e.RSVPs)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.RSVPs)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);
        }
    }
}
