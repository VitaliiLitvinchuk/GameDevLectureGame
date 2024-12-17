using System;
using Assets.Code.Data;

namespace Assets.Code.Gameplay.Services.Wallet
{
    public class WalletService : IWalletService
    {
        private int _balance = 0;

        public int Balance => _balance;

        public void AddCoin() => _balance++;

        public void SubtractCoins(int amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0.");

            if (amount > _balance)
            {
                _balance = 0;
            }
            else
            {
                _balance -= amount;
            }
        }

        public bool IsEnoughMoney(int money)
        {
            return Balance >= money;
        }

        public void Purchase(int price)
        {
            if (!IsEnoughMoney(price))
                throw new InvalidOperationException("Not enough money to purchase item.");

            _balance -= price;
        }

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