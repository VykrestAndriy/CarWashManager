using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Contracts
{
    public interface IWashStrategy
    {
        void ApplyWash(WashDto wash);
    }
}
