using Assets.Code.Gameplay.Logic;
using UnityEngine;

namespace Assets.Code.Gameplay.View.UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField]
        private CoinView _coinView;

        [SerializeField]
        private HealthBar _healthBar;

        public void SetUp(Health health)
        {
            _healthBar.SetUp(health);
        }
    }
}