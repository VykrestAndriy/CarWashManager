using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.States
{
    public class WashState : IWashState
    {
        public void Handle(WashDto wash)
        {
            Console.WriteLine("Мийка в процесі.");
            // Логіка для процесу мийки
        }
    }
}
