using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/LevelData")]
    public class LevelData : ScriptableObject
    {
        public string LevelName;
        public Vector3 PlayerSpawnPoint;
    }
}