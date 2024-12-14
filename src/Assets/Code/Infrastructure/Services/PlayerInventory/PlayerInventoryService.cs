using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.SaveLoad;

namespace Assets.Code.Infrastructure.Services.PlayerInventory
{
    public class PlayerInventoryService : IPlayerInventoryService
    {
        private readonly ISaveLoadService _saveLoad;

        public List<HatTypeId> OwnedHats { get; private set; } = new();

        public HatTypeId SelectedHat { get; private set; } = HatTypeId.Unknown;

        public PlayerInventoryService(ISaveLoadService saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void AddHat(HatTypeId hatTypeId)
        {
            OwnedHats.Add(hatTypeId);
        }

        public bool HasAnyHat()
        {
            return OwnedHats.Count > 0;
        }

        public void Read(PlayerProgress playerProgress)
        {
            OwnedHats = playerProgress.OwnedHats;
            SelectedHat = playerProgress.SelectedHat;
        }

        public void SelectNextHat()
        {
            int index = OwnedHats.FindIndex(x => x == SelectedHat);

            if (index < OwnedHats.Count - 1)
            {
                SelectedHat = OwnedHats[index + 1];
            }
            else
            {
                SelectedHat = HatTypeId.Unknown;
            }

            _saveLoad.SavePlayerProgress();
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = OwnedHats;
            playerProgress.SelectedHat = SelectedHat;
        }
    }
}