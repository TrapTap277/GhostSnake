using _Scripts.Scene;
using _Scripts.Snake.Died;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Button playAgainButton;
        
        public override void InstallBindings()
        {
            Container.Bind<AliveUI>().FromComponentInHierarchy().AsSingle();
            Container.Bind<DieUI>().FromComponentInHierarchy().AsSingle();
            
            Container.BindInterfacesTo<ReloadScene>().AsSingle().WithArguments(playAgainButton);
        }
    }
}