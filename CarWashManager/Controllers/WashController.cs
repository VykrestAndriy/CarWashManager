using Microsoft.AspNetCore.Mvc;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.Models.Washs;

namespace CarWashManager.Controllers;

[ApiController]
[Route("[controller]")]
public class WashController : ControllerBase
{
    private readonly ILogger<WashController> _logger;
    private readonly IWashService _washService;

    public WashController(ILogger<WashController> logger, IWashService washService)
    {
        _logger = logger;
        _washService = washService;
    }

    [HttpGet("get", Name = "GetWash")]
    public async Task<ActionResult<IEnumerable<WashDto>>> GetWash()
    {
        try
        {
            var result = await _washService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch washes");
            return BadRequest();
        }
    }

    [HttpGet("getById/{WashId}", Name = "GetWashById")]
    public async Task<ActionResult<WashDto>> GetWashById([FromRoute] string WashId)
    {
        try
        {
            var result = await _washService.Get(WashId);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch wash with ID = {WashId}");
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateWashRequest request)
    {
        var entity = new WashDto(
            washId: Guid.NewGuid().ToString(),
            washType: request.WashType,
            detergent: request.Detergent,
            serviceType: request.ServiceType,  
            serviceName: "Default Service",
            washTime: request.WashTime,
            amount: request.Amount,
            startTime: DateTime.UtcNow);
        try
        {
            await _washService.Add(entity);
            _logger.LogInformation($"Wash {entity.WashId} successfully created");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to create wash with ID = {entity.WashId}");
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateWashRequest request)
    {
        var entity = new WashDto(
            washId: request.WashId,
            washType: request.WashType,
            detergent: request.Detergent,
            serviceType: request.ServiceType, 
            serviceName: request.ServiceName, 
            washTime: request.WashTime,
            amount: request.Amount,
            startTime: DateTime.UtcNow);

        try
        {
            await _washService.Update(entity);
            _logger.LogInformation($"Wash {entity.WashId} successfully updated");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to update wash with ID = {entity.WashId}");
            return BadRequest();
        }
    }

    [HttpDelete("{WashId}")]
    public async Task<ActionResult> Remove([FromRoute] string WashId)
    {
        try
        {
            await _washService.Remove(WashId);
            _logger.LogInformation($"Wash {WashId} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete wash with ID = {WashId}");
            return BadRequest();
        }
    }
}
