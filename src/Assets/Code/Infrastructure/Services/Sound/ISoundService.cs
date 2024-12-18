using Assets.Code.Data;

namespace Assets.Code.Infrastructure.Services.Sound
{
    public interface ISoundService
    {
        void Play(SoundType sound);
        void Stop(SoundType sound);
        void ChangeSceneSound(SoundType soundType);
    }
}