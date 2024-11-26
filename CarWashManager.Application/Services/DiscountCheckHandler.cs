using CarWashManager.Core.Dtos;
using CarWashManager.Core.Contracts;

namespace CarWashManager.Core.Handlers
{
    public class DiscountCheckHandler : IHandler
    {
        private IHandler _nextHandler;

        public void SetNext(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public async Task HandleRequest(WashDto wash)
        {
            await Handle(wash);  
        }

        public async Task Handle(WashDto wash)
        {
            if (wash.Amount > 100)
            {
                wash.UpdateAmount(wash.Amount - 10);
                Console.WriteLine("Знижка застосована! Новий розмір суми: " + wash.Amount);
            }

            if (_nextHandler != null)
            {
                await _nextHandler.Handle(wash);  
            }
        }
    }
}
