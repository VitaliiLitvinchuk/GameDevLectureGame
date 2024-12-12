using Assets.Code.Data;

namespace Assets.Code.Infrastructure.SaveLoad
{
    public interface IWriteProgress
    {
        void Write(PlayerProgress playerProgress);
    }
}