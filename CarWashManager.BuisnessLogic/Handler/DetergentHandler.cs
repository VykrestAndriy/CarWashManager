﻿using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Handlers
{
    public class DetergentHandler : IHandler
    {
        private IHandler _nextHandler;

        public async Task HandleRequest(WashDto wash)
        {
            await Handle(wash);  
        }
        
        public async Task Handle(WashDto wash)
        {
            if (string.IsNullOrEmpty(wash.Detergent))
            {
                wash.Detergent = "Standard Detergent"; 
                Console.WriteLine("Вибір детергента: встановлено стандартний.");
            }

            if (_nextHandler != null)
            {
                await _nextHandler.HandleRequest(wash); 
            }
        }

        public void SetNext(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }
    }
}
