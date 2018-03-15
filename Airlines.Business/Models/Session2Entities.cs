namespace Airlines.Business.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Session2Entities : DbContext
    {
        public Session2Entities()
            : base("name=Session2Entities1")
        {
        }

        public virtual DbSet<Aircraft> Aircrafts { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Aircraft)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.IATACode)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Routes)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.DepartureAirportID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Routes1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.ArrivalAirportID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Airports)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Offices)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Schedules)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Time)
                .HasPrecision(5);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.EconomyPrice)
                .HasPrecision(19, 4);
        }
    }
}
