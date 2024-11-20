using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.States
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
