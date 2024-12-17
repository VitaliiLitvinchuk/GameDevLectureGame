using System.Collections.Generic;
using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "RandomCollectableSpawnerConfig", menuName = "StaticData/RandomCollectableSpawnerConfig")]
    public class RandomCollectableSpawnerConfig : ScriptableObject
    {
        public GeneralCollectablePriorityType PriorityType;
        public int Count;
        public List<GameObject> CollectablePrefabs;
    }
}