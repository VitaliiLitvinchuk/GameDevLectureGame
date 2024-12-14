using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Data;
using Assets.Code.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelData> _levels;
        private Dictionary<HatTypeId, HatConfig> _hats;

        public PlayerConfig PlayerConfig { get; private set; }

        public HudConfig HudConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
            LoadHats();
        }

        public HatConfig GetHatConfig(HatTypeId hatTypeId)
        {
            return _hats.GetValueOrDefault(hatTypeId);
        }

        public IEnumerable<HatConfig> GetHatConfigs()
        {
            return _hats.Values;
        }

        private void LoadHats()
        {
            _hats = Resources.LoadAll<HatConfig>("Configs/ShopItems/Hats").ToDictionary(x => x.HatTypeId);
        }

        public LevelData GetLevelData(string levelName) => _levels[levelName];

        private void LoadLevels()
        {
            _levels = Resources.LoadAll<LevelData>("Configs/Levels").ToDictionary(x => x.LevelName);
        }

        private void LoadHudConfig()
        {
            HudConfig = Resources.Load<HudConfig>("Configs/HudConfig");
        }

        private void LoadPlayerConfig()
        {
            PlayerConfig = Resources.Load<PlayerConfig>("Configs/PlayerConfig");
        }
    }
}