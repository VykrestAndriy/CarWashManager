using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.States
{
    public class FinishState : IWashState
    {
        public void Handle(WashDto wash)
        {
            Console.WriteLine("Мийка завершена.");
        }
    }
}
