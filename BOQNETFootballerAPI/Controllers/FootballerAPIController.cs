using BOQNETFootballerAPI.Data.Models;
using BOQNETFootballerAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOQNETFootballerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerAPIController : ControllerBase
    {
        private readonly IFootballer _footballerService;
        public FootballerAPIController(IFootballer footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet]
        [Route("Footballers")]
        public IActionResult GetFootballers()
        {
            try
            {
              List<Footballer> footballers = _footballerService.GetAllFootballersAsync().Result;
                if (footballers == null || footballers.Count == 0)
                {
                    return NotFound("No footballers found.");
                }
                return Ok(footballers);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error fetching a list of footballers: {ex.Message}");

            }

        }

        [HttpGet]
        [Route("Footballers/{footballerId}")]
        public IActionResult GetFootballer(int footballerId)
        {
            try
            {
                List<Footballer> footballers = _footballerService.GetAllFootballersAsync().Result;
                if (footballers == null || footballers.Count == 0)
                {
                    return NotFound("No footballers found.");
                }
                return Ok(footballers);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Error fetching footballer with ID {footballerId}: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("Footballers")]
        public IActionResult CreateFootballer([FromBody] Footballer footballer)
        {
            try
            {
                if (footballer == null)
                {
                    return BadRequest("Footballer data is null.");
                }
                var createdFootballer = _footballerService.AddFootballerAsync(footballer).Result;
                return CreatedAtAction(nameof(GetFootballers), new { id = createdFootballer.Id }, createdFootballer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating footballer: {ex.Message}");
            }
        }

        [HttpPatch]
        [Route("Footballers/{footballerId}")]
        public IActionResult UpdateFootballer(int footballerId, [FromBody] Footballer footballer)
        {
            try
            {
                if (footballer == null || footballer.Id != footballerId)
                {
                    return BadRequest("Footballer data is null or ID mismatch.");
                }
                var updatedFootballer = _footballerService.UpdateFootballerAsync(footballer).Result;
                if (updatedFootballer == null)
                {
                    return NotFound($"Footballer with ID {footballerId} not found.");
                }
                return Ok(updatedFootballer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating footballer: {ex.Message}");
            }
        }
    }
}
