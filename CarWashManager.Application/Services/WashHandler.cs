using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Handler
{
    public class WashHandler : IHandler
    {
        private IHandler _nextHandler;

        public WashHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            return Handle(wash); 
        }

        public async Task Handle(WashDto wash)
        {

            Console.WriteLine("Обробка мийки.");

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
