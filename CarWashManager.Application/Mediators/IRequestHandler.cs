using CarWashManager.Application.Commands.Wash;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarWashManager.Application.Handlers
{
    public class UpdateWashCommandHandler : IRequestHandler<UpdateWashCommand, bool>
    {
        public async Task<bool> Handle(UpdateWashCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
