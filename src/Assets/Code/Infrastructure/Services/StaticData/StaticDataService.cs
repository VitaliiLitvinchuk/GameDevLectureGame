using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelData> _levels;

        public PlayerConfig PlayerConfig { get; private set; }

        public HudConfig HudConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
            LoadLevels();
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