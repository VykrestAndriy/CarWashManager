using MediatR;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Application.Queries
{
    public class GetWashByIdQuery : IRequest<WashDto>
    {
        public Guid WashId { get; }  

        public GetWashByIdQuery(Guid washId)
        {
            WashId = washId;
        }
    }
}
