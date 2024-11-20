using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
{
    public class WashExecutionHandler : IHandler
    {
        private IHandler _nextHandler;

        public WashExecutionHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            return Handle(wash); 
        }

        public async Task Handle(WashDto wash)
        {
            Console.WriteLine("Виконання мийки: автомобіль миється.");

            if (_nextHandler != null)
            {
                await _nextHandler.Handle(wash); 
            }
        }

        public void SetNext(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
    }
}
