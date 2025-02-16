using CleanArch.API.Application.Queries.CafeQueries;
using CleanArch.API.Application.Queries.EmployeeQueries;
using CleanArch.API.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /employees?cafe=<cafe>
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployees([FromQuery] string cafe)
        {
            var query = new GetEmployeesQuery { Cafe = cafe };
            var employees = await _mediator.Send(query);

            if (employees == null || employees.Count == 0)
                return NotFound("No employees found for the given criteria.");

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeQuery command)
        {
            // Send the command to create the employee
            var employeeId = await _mediator.Send(command);

            if (employeeId == string.Empty)
            {
                return BadRequest(new { Message = "Employee creation failed" });
            }
  
            return CreatedAtAction(nameof(CreateEmployee), new { id = employeeId }, new { EmployeeId = employeeId });
        }

        // PUT /employee
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeQuery command)
        {
            // Ensure the request has valid data
            if (command == null || string.IsNullOrEmpty(command.Id))
            {
                return BadRequest(new { Message = "Invalid employee data" });
            }

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { Message = "Employee updated successfully" });
            }

            return NotFound(new { Message = "Employee not found" });
        }

        // DELETE /employee
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] string employeeId)
        {
            // Ensure the request has a valid employeeId
            if (string.IsNullOrEmpty(employeeId))
            {
                return BadRequest(new { Message = "Invalid employee ID" });
            }

            var command = new DeleteEmployeeQuery { EmployeeId = employeeId };

            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok(new { Message = "Employee deleted successfully" });
            }

            return NotFound(new { Message = "Employee not found" });
        }
    }
}
