using System.ComponentModel.DataAnnotations;
using Kiosk.Abstractions.Enums;

using KioskAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace KioskAPI.Controllers;

[ApiController]
[Route("staff")]
public class StaffController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IStaffService _staffService;

    public StaffController(ILogger logger, IStaffService staffService)
    {
        _logger = logger;
        _staffService = staffService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStaff([FromQuery(Name = "language"), Required] Language language,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _staffService.GetStaff(language, cancellationToken);
            return Ok(response);
        }
        catch (Exception exception)
        {
            _logger.Error(exception,
                "Something went wrong while getting staff collection. {ExceptionMessage}",
                exception.Message);

            return Problem();
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStaffMember(
        string id,
        [FromQuery(Name = "language"), Required] Language language,
        CancellationToken cancellationToken)
    {
        try
        {
            var staffMember = await _staffService.GetStaffMember(id, language, cancellationToken);
            return staffMember is null ? NotFound() : Ok(staffMember);
        }
        catch (Exception exception)
        {
            _logger.Error(exception,
                "Something went wrong while getting staff member. {ExceptionMessage}",
                exception.Message);

            return Problem();
        }
    }
}