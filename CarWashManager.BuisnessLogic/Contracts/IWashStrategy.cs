using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.Contracts
{
    public interface IWashStrategy
    {
        void ApplyWash(WashDto wash);
    }
}
