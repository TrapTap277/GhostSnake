using _Scripts.Music;
using _Scripts.Snake.Body;
using _Scripts.Snake.Died;
using _Scripts.Snake.MoveLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class SnakeInstaller : MonoInstaller
    {
        [SerializeField] private GameObject snakeBodyPrefab;
        [SerializeField] private Transform snakeTransform;
        [SerializeField] private SnakeConfig snakeConfig;
        [SerializeField] private int initialBodySize = 3;

        [SerializeField] private float distanceBetweenParts;
        [SerializeField] private float distanceToFirstPart;
        [SerializeField] private float smoothSpeed;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("SnakeBody").FromInstance(snakeBodyPrefab).AsCached();
            Container.Bind<Transform>().WithId("SnakeParent").FromInstance(snakeTransform).AsCached();
            Container.Bind<int>().WithId("BodySize").FromInstance(initialBodySize).AsCached();
            Container.Bind<float>().WithId("DistanceBetweenParts").FromInstance(distanceBetweenParts).AsCached();
            Container.Bind<float>().WithId("DistanceToFirstPart").FromInstance(distanceToFirstPart).AsCached();
            Container.Bind<float>().WithId("SmoothSpeed").FromInstance(smoothSpeed).AsCached();

            Container.BindInterfacesAndSelfTo<SnakeBody>().AsCached();
            Container.BindInterfacesTo<CreateSnakeBodyPart>().AsSingle();

            Container.Bind<SnakeBodyPartConfig>().AsSingle();
            Container.Bind<SnakeConfig>().FromInstance(snakeConfig).AsCached();

            // Snake died

            Container.Bind<BaseSnakeMove>().To<Walk>().FromInstance(snakeConfig.Walk).WithArguments(snakeConfig);
            Container.Bind<DieUI>().AsSingle();
            Container.Bind<MusicSwitcher>().FromComponentInHierarchy().AsSingle();
            Container.Bind<SnakeDied>().AsSingle();
        }
    }
}