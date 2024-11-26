using MediatR;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Application.Queries
{
    public class GetWashByIdRequest : IRequest<WashDto>
    {
        public int WashId { get; }

        public GetWashByIdRequest(int washId)
        {
            WashId = washId;
        }
    }
}
