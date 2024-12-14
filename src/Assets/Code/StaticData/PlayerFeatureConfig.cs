using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.StaticData
{

    [CreateAssetMenu(fileName = "PlayerFeatureConfig", menuName = "StaticData/PlayerFeatureConfig")]
    public class PlayerFeatureConfig : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public int Price;
        public PlayerFeatureType FeatureType;
        public ShopItemType Type;
    }
}