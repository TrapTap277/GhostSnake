using UnityEngine;

namespace _Scripts.Snake.Died
{
    public class AliveUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup joyStick;

        private void Start()
        {
            ShowUI();
        }

        public void FadeAliveUI()
        {
            joyStick.alpha = 0;
            joyStick.interactable = false;
            joyStick.blocksRaycasts = false;
        }

        private void ShowUI()
        {
            joyStick.alpha = 1;
            joyStick.interactable = true;
            joyStick.blocksRaycasts = true;
        }
    }
}