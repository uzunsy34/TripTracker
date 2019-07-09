using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options):base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>().HasKey(t => t.TheId);
        }
        public static void SeedData(IServiceProvider serviceProvider)
        {

            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<TripContext>();
            context.Database.EnsureCreated();
            if (context.Trips.Any())
            {
                return;
            }
            context.Trips.AddRange(new Trip[] {
             new Trip
             {
                 Id = 1,
                 Name = "MVP Summit",
                 StartDate = new DateTime(2019, 7, 9),
                 EndDate = new DateTime(2019, 7, 12)

             },
             new Trip
             {
                 Id = 2,
                 Name = "DevIntersection Orlando 2019",
                 StartDate = new DateTime(2019, 7, 25),
                 EndDate = new DateTime(2019, 7, 27)

             },
             new Trip
             {
                 Id = 3,
                 Name = "Build 2019",
                 StartDate = new DateTime(2019, 9, 7),
                 EndDate = new DateTime(2019, 9, 7)

             } });

            context.SaveChanges();
        }
    }

}
