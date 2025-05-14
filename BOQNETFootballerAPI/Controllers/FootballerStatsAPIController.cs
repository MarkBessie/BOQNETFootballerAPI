using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BOQNETFootballerAPI.Controllers
{

    [ApiController]
    [Route("api/Footballers")]
    public class FootballerStatsAPIController : ControllerBase
    {
        private readonly IFootballerStats _footballerStatsService;

        public FootballerStatsAPIController(IFootballerStats footballerStatsService)
        {
            _footballerStatsService = footballerStatsService;
        }

        [HttpGet("{footballerId}/{matchId}/Stats")]
        public async Task<IActionResult> GetFootballerMatchStats(int matchId, int footballerId)
        {
            var matchStats = await _footballerStatsService.GetFootballerMatchStats(matchId, footballerId);

            if (matchStats == null)
                return NotFound($"No match stats found for footballer ID {footballerId} and match ID {matchId}.");

            return Ok(matchStats);
        }

        [HttpPost("Stats")]
        public async Task<IActionResult> CreateFootballerMatchStats([FromBody] FootballerMatchStats footballerMatchStats)
        {
            var createdStats = await _footballerStatsService.CreateFootballerMatchStats(footballerMatchStats);

            return CreatedAtAction(nameof(GetFootballerMatchStats), new
            {
                footballerId = createdStats.FootballerId,
                matchId = createdStats.FootballerMatchStatsId
            }, createdStats);
        }

        [HttpGet("{footballerId}/Stats")]
        public async Task<IActionResult> GetAllFootballerMatchStats(int footballerId)
        {
            var stats = await _footballerStatsService.GetAllFootballerMatchStats(footballerId);

            if (stats == null || stats.Count == 0)
                return NotFound($"No match stats found for footballer ID {footballerId}.");

            return Ok(stats);
        }

        [HttpGet("{footballerId}/Stats/Summary")]
        public async Task<IActionResult> GetFootballerStatsSummary(int footballerId)
        {
            var summary = await _footballerStatsService.GetMatchStatsSummary(footballerId);

            if (summary == null)
                return NotFound($"No summary available for footballer ID {footballerId}.");

            return Ok(summary);
        }
    }
}
