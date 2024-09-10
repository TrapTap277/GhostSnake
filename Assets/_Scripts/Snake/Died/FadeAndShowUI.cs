using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Snake.Died
{
    public abstract class FadeAndShowUI : MonoBehaviour
    {
        [SerializeField] private List<CanvasGroup> uiMovement = new List<CanvasGroup>();

        [SerializeField] private float showValue;

        protected void Awake()
        {
            Initialize();
        }

        protected abstract void Initialize();

        public void FadeAliveUI()
        {
            HideOrShowUI(0, false);
        }

        public void ShowUI()
        {
            HideOrShowUI(showValue, true);
        }

        private void HideOrShowUI(float value, bool isHidden)
        {
            foreach (var group in uiMovement)
            {
                group.alpha = value;
                group.interactable = isHidden;
                group.blocksRaycasts = isHidden;
            }
        }
    }
}