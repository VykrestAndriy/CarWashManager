using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.States
{
    public class FinishState : IWashState
    {
        public void Handle(WashDto wash)
        {
            Console.WriteLine("Мийка завершена.");
            // Логіка для завершення мийки
        }
    }
}
