using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Scene
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;

        private Button _button;

        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(SwitchScene);
        }

        private void SwitchScene()
        {
            var switchScene = new SwitchScene(sceneIndex);
            switchScene.LoadScene();
        }
    }
}