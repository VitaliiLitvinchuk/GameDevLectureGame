using System.Collections.Generic;
using Assets.Code.Data;
using Assets.Code.StaticData;

namespace Assets.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        PlayerConfig PlayerConfig { get; }
        HudConfig HudConfig { get; }
        void LoadAll();
        LevelData GetLevelData(string levelName);
        IEnumerable<HatConfig> GetHatConfigs();
        HatConfig GetHatConfig(HatTypeId hatTypeId);
        IEnumerable<PlayerFeatureConfig> GetPlayerFeatureConfigs();
        PlayerFeatureConfig GetPlayerFeatureConfig(PlayerFeatureType featureType);
    }
}