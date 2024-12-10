using UnityEngine;

namespace Assets.Code.Infrastructure.Factories
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Vector3 position);
        GameObject CreateHud(GameObject player);
    }
}