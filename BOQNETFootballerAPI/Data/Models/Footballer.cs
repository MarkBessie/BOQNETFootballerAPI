using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BOQNETFootballerAPI.Data.Models
{
    public class Footballer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get;set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Position { get; set; } = string.Empty;
        public string Club { get; set; } = string.Empty;

    }
}
