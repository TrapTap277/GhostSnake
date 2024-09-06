using UnityEngine;
using Zenject;

namespace _Scripts.Snake
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            playerConfig.InitMoveBehaviours(); 

            Container.Bind<IMove>()
                .WithId(PlayerConfig.SHIFTING_ID)
                .To<Shifting>()
                .FromInstance(playerConfig.Shifting)
                .AsSingle();
            Container.Bind<IMove>()
                .WithId(PlayerConfig.MOVE_ID)
                .To<Walk>()
                .FromInstance(playerConfig.Walk)
                .AsSingle();
            Container.Bind<IMove>()
                .WithId(PlayerConfig.RUN_ID)
                .To<Run>()
                .FromInstance(playerConfig.Run)
                .AsSingle();

            Container.BindInterfacesTo<InputReader>().AsSingle();
        }
    }
}