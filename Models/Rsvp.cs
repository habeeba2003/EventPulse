// Models/Rsvp.cs
using System.ComponentModel.DataAnnotations;

namespace EventPulse.Models
{
    public class Rsvp
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key - this links the RSVP to a specific Event
        // EF Core uses this number to JOIN the two tables together
        public int EventId { get; set; }

        [Required]
        [EmailAddress] // Validates that the value looks like an email
        [MaxLength(256)]
        public string UserEmail { get; set; } = string.Empty;

        // Automatically recorded when the RSVP is created
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // THE CORE BUSINESS LOGIC FIELD
        // false = confirmed seat
        // true = on the waitlist (event was full when they registered)
        public bool IsWaitlisted { get; set; } = false;

        // Navigation Property - gives us access to the parent Event object
        // EF Core fills this in when we use .Include(r => r.Event) in queries
        public Event? Event { get; set; }
    }
}