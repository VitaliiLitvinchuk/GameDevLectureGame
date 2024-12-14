using System;
using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.SaveLoad;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View.UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField]
        private ShopItem _shopItemPrefab;

        [SerializeField]
        private Transform _contentContainer;
        [Inject]
        private readonly IStaticDataService _staticDataService;

        [Inject]
        private readonly IInstantiator _instantiator;

        private readonly List<ShopItem> _shopItems = new();

        private void Start()
        {
            IEnumerable<HatConfig> hatsConfigs = _staticDataService.GetHatConfigs();

            foreach (HatConfig config in hatsConfigs)
            {
                ShopItem shopItem = _instantiator.InstantiatePrefabForComponent<ShopItem>(_shopItemPrefab, _contentContainer);
                _shopItems.Add(shopItem);
                shopItem.Bought += OnBought;
                shopItem.UpdateView(config.Sprite, config.Price, config.Type, config.HatTypeId);
            }
        }

        private void UpdateShopItemsView()
        {
            foreach (ShopItem shopItem in _shopItems)
            {
                UpdateShopItemView(shopItem);
            }
        }

        private void UpdateShopItemView(ShopItem shopItem)
        {
            switch (shopItem.Type)
            {
                case ShopItemType.Hat:
                    HatConfig config = _staticDataService.GetHatConfig((HatTypeId)shopItem.Identifier);

                    shopItem.UpdateView(config.Sprite, config.Price, config.Type, config.HatTypeId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnBought()
        {
            UpdateShopItemsView();
        }
    }
}