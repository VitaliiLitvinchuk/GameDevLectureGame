using Assets.Code.Data;

namespace Assets.Code.Gameplay.Services.Wallet
{
    public class WalletService : IWalletService
    {
        private int _balance = 0;

        public int Balance => _balance;

        public void AddCoin() => _balance++;

        public void Read(PlayerProgress playerProgress)
        {
            _balance = playerProgress.Coins;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.Coins = _balance;
        }
    }
}