namespace Assets.Code.Gameplay.Logic
{
    public interface ICollectable
    {
        bool IsCollected { get; }
        void Collect(Collector collector);
    }
}