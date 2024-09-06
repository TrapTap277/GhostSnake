using System;
using System.Collections.Generic;
using _Scripts.Food;
using _Scripts.NecessaryInterfaces;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class BootstrapInjector : MonoBehaviour
    {
        public static event Action OnInitialized;

        private readonly List<IInit> _inits = new List<IInit>();

        private readonly List<Installer> _installers = new List<Installer>();

        private void Start()
        {
            Construct();
        }

        //[Inject]
        private void Construct()
        {

            AddInstallers();
            Initialize();
            InstallBindings();
        }

        private void Initialize()
        {
            foreach (var init in _inits) init.Init();

            Debug.LogWarning("2");
            OnInitialized.Invoke();
        }

        private void InstallBindings()
        {
            if (_installers.Count <= 0) return;
            foreach (var installer in _installers) installer.InstallBindings();
        }

        private void AddInstallers()
        {
            
        }
    }
}