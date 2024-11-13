using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.Models.Washs;

namespace CarWashManager.Controllers;

[ApiController]
[Route("[controller]")]
public class CarWashManagerController : ControllerBase
{
    private readonly ILogger<CarWashManagerController> _logger;
    private readonly ITransactionService _carWashTransactionService;

    public CarWashManagerController(ILogger<CarWashManagerController> logger, ITransactionService carWashTransactionService)
    {
        _logger = logger;
        _carWashTransactionService = carWashTransactionService;
    }

    [HttpGet("get", Name = "GetCarWashTransaction")]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetCarWashTransactions()
    {
        try
        {
            var result = await _carWashTransactionService.Get();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch car wash transactions");
            return BadRequest();
        }
    }

    [HttpGet("getById/{CarWashTransactionId}", Name = "GetCarWashTransactionById")]
    public async Task<ActionResult<TransactionDto>> GetCarWashTransactionById([FromRoute] string CarWashTransactionId)
    {
        try
        {
            var result = await _carWashTransactionService.Get(CarWashTransactionId);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to fetch car wash transaction with ID = {CarWashTransactionId}");
            return BadRequest();
        }
    }

    [HttpGet("getTodayCarWashTransactions", Name = "GetTodayCarWashTransactions")]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTodayCarWashTransactions()
    {
        try
        {
            var result = await _carWashTransactionService.GetTodayTransactions();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to fetch today's car wash transactions");
            return BadRequest();
        }
    }

    [HttpPost("addCarWashTransaction", Name = "AddCarWashTransaction")]
    public async Task<ActionResult> Add([FromBody] CreateWashRequest request)
    {
        var entity = new TransactionDto(
        transactionId: Guid.NewGuid().ToString(),
        washId: request.WashId, 
        type: request.TransactionType,
        amount: request.Amount,
        transactionTime: DateTime.UtcNow);

    try
    {
        await _carWashTransactionService.Create(entity);
        _logger.LogInformation($"Car wash transaction {entity.TransactionId} successfully created");
        return Ok();
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"Failed to create car wash transaction with ID = {entity.TransactionId}");
        return BadRequest();
    }
    }

    [HttpDelete("{CarWashTransactionId}")]
    public async Task<ActionResult> Remove([FromRoute] string CarWashTransactionId)
    {
        try
        {
            await _carWashTransactionService.Remove(CarWashTransactionId);
            _logger.LogInformation($"Car wash transaction {CarWashTransactionId} successfully deleted");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to delete car wash transaction with ID = {CarWashTransactionId}");
            return BadRequest();
        }
    }
}
