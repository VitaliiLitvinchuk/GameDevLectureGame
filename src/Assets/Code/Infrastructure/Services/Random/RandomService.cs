using System.Collections.Generic;

namespace Assets.Code.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        public T ChooseFromList<T>(List<T> list)
        {
            if (list.Count == 0)
                return default;

            int index = UnityEngine.Random.Range(0, list.Count);

            return list[index];
        }

        public float Range(float min, float max) => UnityEngine.Random.Range(min, max);
    }
}