using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Gameplay.Services.Wallet
{
    public interface IWalletService : IWriteProgress, IReadProgress
    {
        int Balance { get; }

        void AddCoin();
        bool IsEnoughMoney(int money);
        void Purchase(int price);
        void SubtractCoins(int amount);
    }
}