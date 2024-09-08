using System;
using UnityEngine;

namespace _Scripts.Music
{
    public class MusicSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;

        [SerializeField] private AudioClip _currentAudioClip;

        [SerializeField] private AudioClip _themeClip;
        [SerializeField] private AudioClip _victoryClip;
        [SerializeField] private AudioClip _defeatClip;

        private void Start()
        {
            Switch(MusicCType.Theme);
        }

        public void Switch(MusicCType musicType)
        {
            
            Debug.LogWarning("Playing music");
            SetCurrentClip(musicType);

            _source.Stop();
            _source.PlayOneShot(_currentAudioClip);
            
        }

        private void SetCurrentClip(MusicCType musicType)
        {
            _currentAudioClip = musicType switch
            {
                MusicCType.Theme => _themeClip,
                MusicCType.Victory => _victoryClip,
                MusicCType.Defeat => _defeatClip,
                _ => throw new ArgumentOutOfRangeException(nameof(musicType), musicType, null)
            };
        }
    }
}