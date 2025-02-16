using CleanArch.API.Application.Commands.CafeCommands;
using CleanArch.API.Application.Queries.CafeQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CafeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cafesbylocation")]
        public async Task<IActionResult> GetCafes([FromQuery] string location = null)
        {
            var query = new GetCafesQuery
            {
                Location = location
            };

            var cafes = await _mediator.Send(query);

            if (cafes == null || cafes.Count == 0)
            {
                return NotFound(new { Message = "No cafes found" });
            }

            return Ok(cafes);
        }


        [HttpGet("cafes")]
        public async Task<IActionResult> GetAllCafes()
        {
            // Fetch cafes without any filtering
            var cafes = await _mediator.Send(new GetAllCafesQuery());

            if (cafes == null || cafes.Count == 0)
            {
                return NotFound(new { Message = "No cafes found" });
            }

            return Ok(cafes); // Return all cafes
        }


        [HttpPost("cafe")]
        public async Task<IActionResult> CreateCafe([FromBody] CreateCafeQuery command)
        {

            if (command == null)
            {
                return BadRequest(new { Message = "Invalid cafe data." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeId = await _mediator.Send(command);  // Send the command to create the cafe

            return CreatedAtAction(nameof(CreateCafe), new { id = cafeId }, new { cafeId });  // Return the created cafe id
        }

        // PUT /cafe
        [HttpPut]
        public async Task<IActionResult> UpdateCafe([FromBody] UpdateCafeQuery command)
        {
            // Ensure the request has valid data
            if (command == null || command.CafeId == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid café data" });
            }

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { Message = "Café updated successfully" });
            }

            return NotFound(new { Message = "Café not found" });
        }

        // DELETE /cafe
        [HttpDelete]
        public async Task<IActionResult> DeleteCafe([FromQuery] Guid cafeId)
        {
            // Ensure the request has a valid cafeId
            if (cafeId == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid cafe ID" });
            }

            var command = new DeleteCafeQuery { CafeId = cafeId };

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { Message = "Cafe and its employees deleted successfully" });
            }

            return NotFound(new { Message = "Cafe not found" });
        }



    }
}
