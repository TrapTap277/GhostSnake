using UnityEngine.SceneManagement;

namespace _Scripts.Scene
{
    public class SwitchScene
    {
        private readonly int _sceneIndex;

        public SwitchScene(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(_sceneIndex);
        }
    }
}