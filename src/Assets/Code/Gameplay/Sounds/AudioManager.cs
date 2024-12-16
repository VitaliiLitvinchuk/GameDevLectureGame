using System;
using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Gameplay.Sounds
{
	public class AudioManager : MonoBehaviour
	{
		public static AudioManager instance;

		[HideInInspector]
		public SoundType sceneSound = SoundType.Unknown;

		[SerializeField]
		private Sound[] _sounds;

		void Awake()
		{
			if (instance != null)
			{
				Destroy(gameObject);
				return;
			}
			else
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}

			foreach (Sound s in _sounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				s.source.volume = s.volume;
				s.source.pitch = s.pitch;
				s.source.loop = s.loop;
			}
		}

		public void ChangeSceneSound(SoundType soundType)
		{
			if (soundType != SoundType.Unknown)
				instance.StartCoroutine(instance.FadeOutAndPlayNewSound(soundType));
		}

		private System.Collections.IEnumerator FadeOutAndPlayNewSound(SoundType newSoundType)
		{
			Sound currentSound = Array.Find(_sounds, item => item.type == sceneSound);
			Sound newSound = Array.Find(_sounds, item => item.type == newSoundType);

			if (currentSound != null && currentSound.source.isPlaying)
			{
				yield return currentSound.source.DOFade(0, 1f).WaitForCompletion();
				currentSound.source.Stop();
				currentSound.source.volume = currentSound.volume;
			}

			if (newSound != null)
			{
				newSound.source.volume = 0;
				newSound.source.Play();
				newSound.source.DOFade(newSound.volume, 1f);
			}

			sceneSound = newSoundType;
		}

		public void Play(SoundType sound)
		{
			Sound s = Array.Find(_sounds, item => item.type == sound);
			s.source.Play();
		}
		public void Stop(SoundType sound)
		{
			Sound s = Array.Find(_sounds, item => item.type == sound);
			s.source.Stop();
		}
	}
}
