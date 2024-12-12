using Assets.Code.Data;

namespace Assets.Code.Infrastructure.SaveLoad
{
    public interface IReadProgress
    {
        void Read(PlayerProgress playerProgress);
    }
}