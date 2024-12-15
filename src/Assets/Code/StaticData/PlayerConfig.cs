
using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "StaticData/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public GameObject DeathMenuPrefab;
        public GameObject PauseMenuPrefab;
        public float StartHealth;
    }
}