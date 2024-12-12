using Assets.Code.Data;
using Assets.Code.Infrastructure.SaveLoad;
using Assets.Code.Infrastructure.SaveLoadRegistry;
using Assets.Code.Infrastructure.Services.Progress;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly string PlayerProgressKey = typeof(PlayerProgress).Name;
        private readonly IProgressService _progressService;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public SaveLoadService(IProgressService progressService, ISaveLoadRegistryService saveLoadRegistryService)
        {
            _progressService = progressService;
            _saveLoadRegistryService = saveLoadRegistryService;
        }

        public void SavePlayerProgress()
        {
            foreach (IWriteProgress progressWriter in _saveLoadRegistryService.ProgressWriters)
                progressWriter.Write(_progressService.PlayerProgress);

            string json = JsonConvert.SerializeObject(_progressService.PlayerProgress);
            PlayerPrefs.SetString(PlayerProgressKey, json);
        }

        public PlayerProgress LoadPlayerProgress()
        {
            if (PlayerPrefs.HasKey(PlayerProgressKey))
            {
                string json = PlayerPrefs.GetString(PlayerProgressKey);
                return JsonConvert.DeserializeObject<PlayerProgress>(json);
            }

            return PlayerProgress.Empty;
        }
    }
}