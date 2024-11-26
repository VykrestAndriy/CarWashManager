using CarWashManager.Application.Queries;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using MediatR;

namespace CarWashManager.Application.Handlers.Wash
{
    public class GetWashByIdQueryHandler : IRequestHandler<GetWashByIdQuery, WashDto>
    {
        private readonly IWashService _washService;

        public GetWashByIdQueryHandler(IWashService washService)
        {
            _washService = washService;
        }

        public async Task<WashDto> Handle(GetWashByIdQuery request, CancellationToken cancellationToken)
        {
            var washDto = await _washService.GetWashByIdAsync(request.WashId);
            return washDto;
        }
    }
}
