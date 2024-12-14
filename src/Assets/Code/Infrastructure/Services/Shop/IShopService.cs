using Assets.Code.Data;
using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Infrastructure.Services.Shop
{
    public interface IShopService : IReadProgress, IWriteProgress
    {
        void BuyItem(ShopItemType type, object identifier);
        bool CanBuyItem(ShopItemType type, object identifier);
    }
}