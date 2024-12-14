using UnityEngine;

namespace Assets.Code.Gameplay.Logic
{
    public interface IMoving
    {
        (Transform PointA, Transform PointB) GetPoints();
    }
}