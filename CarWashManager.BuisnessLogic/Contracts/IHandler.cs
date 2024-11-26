using CarWashManager.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Contracts
{
    public interface IHandler
    {
        void SetNext(IHandler nextHandler);
        Task HandleRequest(WashDto wash);
        Task Handle(WashDto wash);
    }
}
