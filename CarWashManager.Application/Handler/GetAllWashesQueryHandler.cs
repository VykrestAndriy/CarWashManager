using CarWashManager.Application.Queries;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using MediatR;

namespace CarWashManager.Application.Handlers.Wash
{
    public class GetAllWashesQueryHandler : IRequestHandler<GetAllWashesQuery, IEnumerable<WashDto>>
    {
        private readonly IWashService _washService;

        public GetAllWashesQueryHandler(IWashService washService)
        {
            _washService = washService;
        }

        public async Task<IEnumerable<WashDto>> Handle(GetAllWashesQuery request, CancellationToken cancellationToken)
        {
            var washes = await _washService.GetAllWashesAsync();
            return washes;
        }
    }
}
