using _Scripts.Snake;
using _Scripts.Snake.MoveLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private SnakeConfig snakeConfig;

        public override void InstallBindings()
        {
            snakeConfig.InitMoveBehaviours(); 

            Container.Bind<IMove>()
                .WithId(SnakeConfig.SHIFTING_ID)
                .To<Shifting>()
                .FromInstance(snakeConfig.Shifting)
                .AsSingle();
            Container.Bind<IMove>()
                .WithId(SnakeConfig.MOVE_ID)
                .To<Walk>()
                .FromInstance(snakeConfig.Walk)
                .AsSingle();
            Container.Bind<IMove>()
                .WithId(SnakeConfig.RUN_ID)
                .To<Run>()
                .FromInstance(snakeConfig.Run)
                .AsSingle();

            Container.BindInterfacesTo<InputReader>().AsSingle();
        }
    }
}