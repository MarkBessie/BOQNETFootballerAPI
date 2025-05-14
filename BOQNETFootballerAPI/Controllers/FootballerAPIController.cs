using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOQNETFootballerAPI.Controllers
{
    
    [ApiController]
    [Route("api/Footballers")]
    public class FootballerAPIController : ControllerBase
    {
        private readonly IFootballer _footballerService;
        public FootballerAPIController(IFootballer footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFootballers()
        {
            var footballers = await _footballerService.GetAllFootballersAsync();

            if (footballers == null || footballers.Count == 0)
                return NotFound("No footballers found.");

            return Ok(footballers);
        }

        [HttpGet("{footballerId}")]
        public async Task<IActionResult> GetFootballer(int footballerId)
        {
            var footballer = await _footballerService.GetFootballerByIdAsync(footballerId);

            if (footballer == null)
                return NotFound($"Footballer with ID {footballerId} not found.");

            return Ok(footballer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFootballer([FromBody] Footballer footballer)
        {
            var createdFootballer = await _footballerService.AddFootballerAsync(footballer);

            return CreatedAtAction(nameof(GetFootballer), new { footballerId = createdFootballer.FootballerId }, createdFootballer);
        }

        [HttpPatch("{footballerId}")]
        public async Task<IActionResult> UpdateFootballer(int footballerId, [FromBody] Footballer footballer)
        {
            if (footballerId != footballer.FootballerId)
                return BadRequest("Footballer ID mismatch.");

            var updatedFootballer = await _footballerService.UpdateFootballerAsync(footballer);

            if (updatedFootballer == null)
                return NotFound($"Footballer with ID {footballerId} not found.");

            return Ok(updatedFootballer);
        }
    }
}
