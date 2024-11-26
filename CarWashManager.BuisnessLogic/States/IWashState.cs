using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.States
{
    public interface IWashState
    {
        void Handle(WashDto wash);
    }
}
