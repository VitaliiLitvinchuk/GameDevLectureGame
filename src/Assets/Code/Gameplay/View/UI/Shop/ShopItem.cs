using System;
using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Code.Gameplay.View.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private TextMeshProUGUI _price;

        [SerializeField]
        private Button _buyButton;

        [Inject]
        private readonly IShopService _shopService;

        private ShopItemType _type;

        public ShopItemType Type => _type;

        private object _identifier = null;

        public object Identifier => _identifier;

        public event Action Bought;

        private void Awake()
        {
            _buyButton.onClick.AddListener(Buy);
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveAllListeners();
        }

        private void Buy()
        {
            _shopService.BuyItem(_type, Identifier);
            Bought?.Invoke();
        }

        public void UpdateView(Sprite sprite, int price, ShopItemType type, object identifier)
        {
            _image.sprite = sprite;
            _price.text = price.ToString();
            _type = type;
            _identifier = identifier;

            _buyButton.interactable = _shopService.CanBuyItem(type, identifier);
        }
    }
}