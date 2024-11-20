﻿using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
{
    public class FeedbackHandler : IHandler
    {
        private IHandler _nextHandler;

        public FeedbackHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public Task HandleRequest(WashDto wash)
        {
            Console.WriteLine("Збір відгуків: клієнт залишив відгук про мийку.");

            return Handle(wash);
        }

        public async Task Handle(WashDto wash)
        {
            Console.WriteLine("Збір відгуків: клієнт залишив відгук про мийку.");

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
