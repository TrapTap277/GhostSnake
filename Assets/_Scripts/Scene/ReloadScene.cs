using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Scene
{
    public class ReloadScene : IInitializable, IDisposable
    {
        private readonly Button _playAgainButton;

        public ReloadScene(Button playAgainButton)
        {
            _playAgainButton = playAgainButton;
        }

        private void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Initialize()
        {
            _playAgainButton.onClick.AddListener(Reload);
        }

        public void Dispose()
        {
            _playAgainButton.onClick.RemoveListener(Reload);
        }
    }
}