using System.Collections.Generic;
using System.Linq;
using Assets.Code.Data;
using Assets.Code.StaticData;
using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Infrastructure.Services.Sound
{
    public class SoundService : ISoundService
    {
        private const float _switchMusicDuration = 1f;
        private const string Name = "SoundManager";
        public SoundType sceneSound = SoundType.Unknown;
        private readonly Dictionary<SoundType, SoundConfig> _sounds;

        public SoundService()
        {
            GameObject soundManager = new(Name);
            Object.DontDestroyOnLoad(soundManager);

            _sounds = Resources.LoadAll<SoundConfig>("Configs/Sounds").ToDictionary(x => x.Type);

            foreach (SoundConfig sound in _sounds.Values)
            {
                sound.Source = soundManager.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
                sound.Source.loop = sound.Loop;
            }

            _sounds.Add(SoundType.Unknown, null);
        }

        public void ChangeSceneSound(SoundType soundType)
        {
            if (soundType != SoundType.Unknown)
                FadeOutAndPlayNewSound(soundType);
        }

        private void FadeOutAndPlayNewSound(SoundType newSoundType)
        {
            SoundConfig currentSound = _sounds[sceneSound];
            SoundConfig newSound = _sounds[newSoundType];

            if (currentSound != null && currentSound.Source.isPlaying)
            {
                currentSound.Source.DOFade(0, _switchMusicDuration)
                    .OnComplete(() =>
                    {
                        currentSound.Source.Stop();
                        currentSound.Source.volume = currentSound.Volume;
                    });
            }

            if (newSound != null)
            {
                newSound.Source.volume = 0;
                newSound.Source.Play();
                newSound.Source.DOFade(newSound.Volume, 1f);
            }

            sceneSound = newSoundType;
        }

        public void Play(SoundType sound)
        {
            SoundConfig s = _sounds[sound];
            s.Source.Play();
        }
        public void Stop(SoundType sound)
        {
            SoundConfig s = _sounds[sound];
            s.Source.Stop();
        }
    }
}