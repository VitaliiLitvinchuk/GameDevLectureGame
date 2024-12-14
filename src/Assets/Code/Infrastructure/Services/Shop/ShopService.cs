using System;
using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Gameplay.Services.Wallet;
using Assets.Code.Infrastructure.Services.SaveLoad;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.Shop
{
    public class ShopService : IShopService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly ISaveLoadService _saveLoadService;
        private List<HatTypeId> _ownedHats = new();

        public ShopService(IStaticDataService staticDataService, IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadService = saveLoadService;
        }

        public void BuyItem(ShopItemType type, object identifier)
        {
            if (!CanBuyItem(type, identifier))
                throw new InvalidOperationException($"Cannot buy item {type} with identifier {identifier} because player doesn't have enough money or already owns this item.");

            switch (type)
            {
                case ShopItemType.Hat:
                    var hatTypeId = (HatTypeId)identifier;
                    _ownedHats.Add(hatTypeId);
                    _walletService.Purchase(_staticDataService.GetHatConfig(hatTypeId).Price);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            _saveLoadService.SavePlayerProgress();
        }

        public bool CanBuyItem(ShopItemType type, object identifier)
        {
            return type switch
            {
                ShopItemType.Hat => CanBuyHat((HatTypeId)identifier),
                _ => false,
            };
        }

        public void Read(PlayerProgress playerProgress)
        {
            _ownedHats = playerProgress.OwnedHats;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = _ownedHats;
        }

        private bool CanBuyHat(HatTypeId hatTypeId)
        {
            HatConfig config = _staticDataService.GetHatConfig(hatTypeId);
            return _walletService.IsEnoughMoney(config.Price) && !_ownedHats.Contains(hatTypeId);
        }
    }
}