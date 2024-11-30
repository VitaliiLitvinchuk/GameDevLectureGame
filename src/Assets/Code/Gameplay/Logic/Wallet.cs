using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField]
        private int _balance = 0;

        public int Balance => _balance;

        public void AddCoin() => _balance++;
    }
}