using System;
using UnityEngine;

namespace _Scripts.Music
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioSource source;

        [SerializeField] private AudioClip themeClip;
        [SerializeField] private AudioClip victoryClip;
        [SerializeField] private AudioClip defeatClip;

        private AudioClip _currentAudioClip;

        private void Start()
        {
            SetCurrentClip(MusicType.Theme);
            Switch();
            SetCurrentClip(MusicType.Defeat);
        }

        public void Switch()
        {
            if (source.isPlaying) Stop();

            Play();
        }

        private void Play()
        {
            source.PlayOneShot(_currentAudioClip);
        }

        private void Stop()
        {
            source.Stop();
        }

        private void SetCurrentClip(MusicType musicType)
        {
            switch (musicType)
            {
                case MusicType.Theme:
                    ChangeLoop(true);
                    _currentAudioClip = themeClip;
                    break;
                case MusicType.Victory:
                    ChangeLoop(false);
                    _currentAudioClip = victoryClip;
                    break;
                case MusicType.Defeat:
                    ChangeLoop(false);
                    _currentAudioClip = defeatClip;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(musicType), musicType, null);
            }
        }

        private void ChangeLoop(bool change)
        {
            source.loop = change;
        }

        private void OnEnable()
        {
            ScoreCounter.ScoreCounter.OnSetMusicType += SetCurrentClip;
        }

        private void OnDisable()
        {
            ScoreCounter.ScoreCounter.OnSetMusicType -= SetCurrentClip;
        }
    }
}