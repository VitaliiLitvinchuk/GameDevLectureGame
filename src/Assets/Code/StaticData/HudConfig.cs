using Assets.Code.Gameplay.View.UI;
using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "HudConfig", menuName = "StaticData/HudConfig")]
    public class HudConfig : ScriptableObject
    {
        public GameObject HudPrefab;
    }
}