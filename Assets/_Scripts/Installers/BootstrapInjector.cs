using System;
using UnityEngine;

namespace _Scripts.Installers
{
    public class BootstrapInjector : MonoBehaviour
    {
        public static event Action OnInitialized;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            OnInitialized?.Invoke();
        }
    }
}