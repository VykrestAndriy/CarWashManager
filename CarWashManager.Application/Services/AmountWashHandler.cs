using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Handlers
{
    public class AmountCheckHandler : IHandler
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
            if (wash.Amount <= 0)
            {
                throw new InvalidOperationException("Amount must be greater than zero.");
            }

            if (_nextHandler != null)
            {
                await _nextHandler.Handle(wash);  
            }
        }
    }
}
