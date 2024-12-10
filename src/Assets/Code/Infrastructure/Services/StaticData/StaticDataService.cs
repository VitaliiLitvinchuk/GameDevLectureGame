using System;
using Assets.Code.StaticData;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public PlayerConfig PlayerConfig { get; private set; }

        public HudConfig HudConfig { get; private set; }

        public void LoadAll()
        {
            LoadPlayerConfig();
            LoadHudConfig();
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