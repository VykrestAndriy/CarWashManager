using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.States
{
    public class StartState : IWashState
    {
        public void Handle(WashDto wash)
        {
            Console.WriteLine("Мийка почалася.");
            // Логіка для початкового стану мийки
        }
    }
}
