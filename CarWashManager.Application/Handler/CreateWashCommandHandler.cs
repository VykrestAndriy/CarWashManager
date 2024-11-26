using CarWashManager.Application.Commands.Wash;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using CarWashManager.Core.Enums; 
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarWashManager.Application.Handlers.Wash
{
    public class CreateWashCommandHandler : IRequestHandler<CreateWashCommand, Guid>
    {
        private readonly IWashService _washService;
        private readonly ILogger<CreateWashCommandHandler> _logger;

        public CreateWashCommandHandler(IWashService washService, ILogger<CreateWashCommandHandler> logger)
        {
            _washService = washService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateWashCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.WashType) || string.IsNullOrWhiteSpace(request.ServiceType) || string.IsNullOrWhiteSpace(request.ServiceName))
            {
                throw new ArgumentException("Invalid input parameters");
            }

            if (!Enum.TryParse(request.WashType, out WashType washType))
            {
                throw new ArgumentException("Invalid WashType");
            }

            if (!Enum.TryParse(request.ServiceType, out ServiceType serviceType))
            {
                throw new ArgumentException("Invalid ServiceType");
            }

            var washDto = new WashDto(
                Guid.NewGuid().ToString(),
                washType,  
                request.Detergent,
                serviceType,
                request.ServiceName,
                request.Amount,
                request.WashTime,
                DateTime.Now
            );

            try
            {
                await _washService.CreateWashAsync(washDto);
                _logger.LogInformation("Wash created successfully with ID: {WashId}", washDto.WashId);

                return Guid.Parse(washDto.WashId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating wash");
                throw;
            }
        }
    }
}
