using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Gameplay.View.UI.Shop;
using Assets.Code.Infrastructure.SaveLoad;

namespace Assets.Code.Infrastructure.Services.PlayerInventory
{
    public interface IPlayerInventoryService : IReadProgress, IWriteProgress
    {
        HatTypeId SelectedHat { get; }
        List<HatTypeId> OwnedHats { get; }
        void AddHat(HatTypeId hatTypeId);
        void AddPlayerFeature(PlayerFeatureType featureType);
        bool HasAnyHat();
        void SelectNextHat();
        int GetPlayerFeatureCount(PlayerFeatureType featureType);
    }
}