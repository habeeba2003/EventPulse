// Data/ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EventPulse.Models;

namespace EventPulse.Data
{
    // IdentityDbContext gives us all the built-in auth tables
    // (AspNetUsers, AspNetRoles, etc.) for free
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // These two lines tell EF Core to create Events and Rsvps tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Rsvp> Rsvps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Always call base first when using Identity
            base.OnModelCreating(builder);

            // Define the relationship between Event and Rsvp
            // One Event has Many Rsvps
            // If an Event is deleted, all its Rsvps are deleted too (Cascade)
            builder.Entity<Rsvp>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Rsvps)
                .HasForeignKey(r => r.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data - this inserts sample events automatically
            // when we run migrations, so the app has data immediately
            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Introduction to .NET 8",
                    Description = "A hands-on workshop covering the fundamentals of .NET 8 and C# for beginners. Learn the basics of building modern web applications.",
                    Date = DateTime.UtcNow.AddDays(7),
                    MaxCapacity = 30
                },
                new Event
                {
                    Id = 2,
                    Title = "Blazor Deep Dive",
                    Description = "An advanced session exploring Blazor Server and WebAssembly, component architecture, and real-time UI updates using SignalR.",
                    Date = DateTime.UtcNow.AddDays(14),
                    MaxCapacity = 20
                },
                new Event
                {
                    Id = 3,
                    Title = "Entity Framework Core Workshop",
                    Description = "Practical guide to EF Core — Code First migrations, relationships, LINQ queries, and performance optimization techniques.",
                    Date = DateTime.UtcNow.AddDays(21),
                    MaxCapacity = 25
                }
            );
        }
    }
}