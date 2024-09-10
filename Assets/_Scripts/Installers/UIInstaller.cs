using _Scripts.ScoreCounter;
using _Scripts.Snake.Died;
using Zenject;

namespace _Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DieUI>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<AliveUI>().FromComponentInHierarchy().AsSingle().NonLazy();

            Container.Bind<ScoreUI>().AsSingle();

            Container.BindInterfacesAndSelfTo<SnakeDied>().AsSingle();
        }
    }
}