namespace Assets.Code.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        public float Range(float min, float max) => UnityEngine.Random.Range(min, max);
    }
}