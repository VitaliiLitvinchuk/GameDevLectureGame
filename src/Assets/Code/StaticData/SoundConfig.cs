using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "StaticData/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        public SoundType Type;
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 1;

        [Range(-3f, 3f)]
        public float Pitch = 1;

        public bool Loop = false;

        [HideInInspector]
        public AudioSource Source;
    }
}