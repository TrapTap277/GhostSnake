using _Scripts.Music;
using Zenject;

namespace _Scripts.Installers
{
    public class MusicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MusicSwitcher>().FromComponentInHierarchy().AsSingle();
        }
    }
}