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
        private Dictionary<PlayerFeatureType, PlayerFeatureConfig> _features;

        public PlayerConfig PlayerConfig { get; private set; }

        public HudConfig HudConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
            LoadHats();
            LoadFeatures();
        }

        public HatConfig GetHatConfig(HatTypeId hatTypeId)
        {
            return _hats.GetValueOrDefault(hatTypeId);
        }

        public IEnumerable<HatConfig> GetHatConfigs()
        {
            return _hats.Values;
        }

        public PlayerFeatureConfig GetPlayerFeatureConfig(PlayerFeatureType featureType)
        {
            return _features.GetValueOrDefault(featureType);
        }

        public IEnumerable<PlayerFeatureConfig> GetPlayerFeatureConfigs()
        {
            return _features.Values;
        }

        public LevelData GetLevelData(string levelName) => _levels[levelName];

        private void LoadFeatures()
        {
            _features = Resources.LoadAll<PlayerFeatureConfig>("Configs/ShopItems/PlayerFeatures").ToDictionary(x => x.FeatureType);
        }

        private void LoadHats()
        {
            _hats = Resources.LoadAll<HatConfig>("Configs/ShopItems/Hats").ToDictionary(x => x.HatTypeId);
        }

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