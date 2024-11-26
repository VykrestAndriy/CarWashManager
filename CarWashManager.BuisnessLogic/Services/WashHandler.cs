using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using System;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
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
