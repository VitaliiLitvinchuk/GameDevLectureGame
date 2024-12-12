using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Gameplay.Services.Wallet
{
    public interface IWalletService : IWriteProgress, IReadProgress
    {
        int Balance { get; }

        void AddCoin();
    }
}