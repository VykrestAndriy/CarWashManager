using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.Infrastructure.Enums;
using System;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
{
    public class WashPreparationHandler : IHandler
    {
        private IHandler _nextHandler;

        public WashPreparationHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            return Handle(wash); 
        }

        public async Task Handle(WashDto wash)
        {
            if (wash.WashType == WashType.FullService)
            {
                Console.WriteLine("Підготовка мийки: перевірка обладнання та води.");
            }

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
