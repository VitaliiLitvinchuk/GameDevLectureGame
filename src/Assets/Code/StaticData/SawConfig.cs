using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "SawConfig", menuName = "StaticData/SawConfig")]
    public class SawConfig : ScriptableObject
    {
        public GameObject SawPrefab;
        public GameObject DangerIcon;
        public float ShowDangerTime;
        public float DurationExist;
        public float DurationIn;
        public float DamageInterval;
        public float DamageAmount;
    }
}