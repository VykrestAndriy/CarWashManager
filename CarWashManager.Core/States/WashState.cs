using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.States
{
    public class WashState : IWashState
    {
        public void Handle(WashDto wash)
        {
            Console.WriteLine("Мийка в процесі.");
        }
    }
}
