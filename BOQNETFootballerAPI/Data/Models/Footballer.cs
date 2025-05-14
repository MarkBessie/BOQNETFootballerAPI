using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BOQNETFootballerAPI.Data.Models
{
    public class Footballer
    {
        [Key]
        public int FootballerId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = "Not Provided";

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [StringLength(50, ErrorMessage = "Position cannot exceed 50 characters.")]
        public string? Position { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Club name cannot exceed 100 characters.")]
        public string? Club { get; set; } = string.Empty;
    }
}
