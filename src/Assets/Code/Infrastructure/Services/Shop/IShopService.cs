using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Shop
{
    public interface IShopService
    {
        void BuyItem(ShopItemType type, object identifier);
        bool CanBuyItem(ShopItemType type, object identifier);
    }
}