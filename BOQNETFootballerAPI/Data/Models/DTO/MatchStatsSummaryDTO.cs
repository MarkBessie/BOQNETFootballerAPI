namespace BOQNETFootballerAPI.Data.Models.DTO
{
    public class MatchStatsSummaryDto
    {
        public int FootballerId { get; set; }
        public int TotalGoals { get; set; }
        public int TotalAssists { get; set; }
        public int TotalMatches { get; set; }
        public int TotalMinutesPlayed { get; set; }
        public double AveragePassCompletionPercentage { get; set; }
    }
}
