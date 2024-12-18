using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.Random
{
    public interface IRandomService
    {
        T ChooseFromList<T>(List<T> collectables);
        float Range(float min, float max);
        float RoundRange(float min, float max);
    }
}