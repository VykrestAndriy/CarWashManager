using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Handler
{
    public class PaymentHandler : IHandler
    {
        private IHandler _nextHandler;

        public PaymentHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            Console.WriteLine("Оплата: перевірка платіжних реквізитів.");
            return Handle(wash); 
        }

        public async Task Handle(WashDto wash)
        {
            Console.WriteLine("Оплата: перевірка платіжних реквізитів.");

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
