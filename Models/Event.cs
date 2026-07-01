// Models/Event.cs
using System.ComponentModel.DataAnnotations;

namespace EventPulse.Models
{
    public class Event
    {
        // Primary key - EF Core automatically makes this the database ID
        public int Id { get; set; }

        // [Required] means this field cannot be empty
        // [MaxLength] limits how many characters can be stored
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        // The hard cap - no more registrations allowed beyond this number
        public int MaxCapacity { get; set; }

        // This is a Navigation Property
        // It tells EF Core: one Event can have many Rsvps
        // We never set this manually - EF Core fills it automatically
        public ICollection<Rsvp> Rsvps { get; set; } = new List<Rsvp>();
    }
}