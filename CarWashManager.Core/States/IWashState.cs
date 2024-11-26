using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.States
{
    public interface IWashState
    {
        void Handle(WashDto wash);
    }
}
