using _Scripts.Snake.MoveLogic;
using Zenject;

namespace _Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMove>().WithId(SnakeConfig.SHIFTING_ID).To<Shifting>().AsCached();
            Container.Bind<IMove>().WithId(SnakeConfig.MOVE_ID).To<Walk>().AsCached();
            Container.Bind<IMove>().WithId(SnakeConfig.RUN_ID).To<Run>().AsCached();

            Container.BindInterfacesTo<InputReader>().AsSingle().NonLazy();
        }
    }
}