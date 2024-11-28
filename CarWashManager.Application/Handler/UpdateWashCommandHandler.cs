using CarWashManager.Application.Commands.Wash;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using CarWashManager.Core.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarWashManager.Application.Handlers.Wash
{
    public class UpdateWashCommandHandler : IRequestHandler<UpdateWashCommand, bool>
    {
        private readonly IWashService _washService;
        private readonly ILogger<UpdateWashCommandHandler> _logger;

        public async Task<bool> Handle(UpdateWashCommand request, CancellationToken cancellationToken)
        {
            if (request.WashId == Guid.Empty)
            {
                _logger.LogWarning("Invalid WashId provided: {WashId}", request.WashId);
                throw new ArgumentException("Invalid WashId", nameof(request.WashId));
            }

            var existingWash = await _washService.GetWashByIdAsync(request.WashId);

            if (existingWash == null)
            {
                _logger.LogWarning("Wash with ID {WashId} not found", request.WashId);
                throw new ArgumentException("Wash not found", nameof(request.WashId));
            }

            if (!Enum.TryParse(request.WashType, out WashType washType))
            {
                _logger.LogWarning("Invalid WashType: {WashType}", request.WashType);
                throw new ArgumentException("Invalid WashType", nameof(request.WashType));
            }

            if (!Enum.TryParse(request.ServiceType, out ServiceType serviceType))
            {
                _logger.LogWarning("Invalid ServiceType: {ServiceType}", request.ServiceType);
                throw new ArgumentException("Invalid ServiceType", nameof(request.ServiceType));
            }

            existingWash.UpdateWashDetails(washType, serviceType, request.ServiceName, request.Amount, request.WashTime);

            try
            {
                await _washService.UpdateWashAsync(existingWash);
                _logger.LogInformation("Wash with ID {WashId} updated successfully", request.WashId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating wash with ID {WashId}", request.WashId);
                throw;  
            }
        }
    }
}
