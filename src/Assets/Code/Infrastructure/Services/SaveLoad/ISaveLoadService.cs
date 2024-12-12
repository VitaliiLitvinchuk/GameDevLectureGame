using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SavePlayerProgress();
        PlayerProgress LoadPlayerProgress();
    }
}