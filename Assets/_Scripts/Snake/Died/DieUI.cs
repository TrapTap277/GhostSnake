using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Snake.Died
{
    public class DieUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup dieUI;

        private void Awake()
        {
            FadeUI();
        }

        private void FadeUI()
        {
            dieUI.alpha = 0;
            dieUI.interactable = false;
            dieUI.blocksRaycasts = false;
        }

        public void ShowDieUI()
        { 
            dieUI.alpha = 1;
            dieUI.interactable = true;
            dieUI.blocksRaycasts = true;
            
            Debug.LogWarning("Show die UI");
            // Todo Show UI
        }
    }
}