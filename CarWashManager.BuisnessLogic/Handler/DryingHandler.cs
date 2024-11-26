using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
{
    public class DryingHandler : IHandler
    {
        private IHandler _nextHandler;

        public DryingHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            Console.WriteLine("Сушіння: автомобіль сушиться після мийки.");

            return Handle(wash);
        }

        public async Task Handle(WashDto wash)
        {
            Console.WriteLine("Сушіння: автомобіль сушиться після мийки.");

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
