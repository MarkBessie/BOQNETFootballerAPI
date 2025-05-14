using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOQNETFootballerAPI.Data.Models
{
    public class FootballerMatchStats
    {
        [Key]
        public int FootballerMatchStatsId { get; set; }

        [Required(ErrorMessage = "FootballerId is required.")]
        public int FootballerId { get; set; }

        [Range(0, 120, ErrorMessage = "Minutes played must be between 0 and 120.")]
        public int MinutesPlayed { get; set; }

        [Range(0, 20, ErrorMessage = "Goals scored must be between 0 and 20.")]
        public int GoalsScored { get; set; }

        [Range(0, 20, ErrorMessage = "Assists must be between 0 and 20.")]
        public int Assists { get; set; }

        [Range(0, 100, ErrorMessage = "Pass completion % must be between 0 and 100.")]
        public double PassCompletionPercentage { get; set; }

        [Required(ErrorMessage = "Opposition name is required.")]
        [StringLength(100, ErrorMessage = "Opposition name cannot exceed 100 characters.")]
        public string Opposition { get; set; } = "Not Opponent Provided";
    }
}
