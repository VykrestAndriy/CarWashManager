using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Contracts
{
    public interface IHandler
    {
        void SetNext(IHandler nextHandler);
        Task HandleRequest(WashDto wash);
        Task Handle(WashDto wash);
    }
}
