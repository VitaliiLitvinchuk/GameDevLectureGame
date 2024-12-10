using Assets.Code.StaticData;

namespace Assets.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        PlayerConfig PlayerConfig { get; }
        HudConfig HudConfig { get; }
        void LoadAll();
    }
}