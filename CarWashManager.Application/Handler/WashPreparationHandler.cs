using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using CarWashManager.Core.Enums;

namespace CarWashManager.Core.Handler
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
