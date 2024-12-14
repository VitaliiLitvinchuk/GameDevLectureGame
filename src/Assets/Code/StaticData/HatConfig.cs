using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "HatConfig", menuName = "StaticData/HatConfig")]
    public class HatConfig : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public int Price;
        public HatTypeId HatTypeId;
        public ShopItemType Type;
    }
}
