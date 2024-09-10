using _Scripts.Snake.Body;
using _Scripts.Snake.Eat;
using _Scripts.Snake.MoveLogic;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class SnakeInstaller : MonoInstaller
    {
        [SerializeField] private GameObject snake;

        [SerializeField] private GameObject snakeBodyPrefab;
        [SerializeField] private Transform snakeTransform;
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
            Container.Bind<SnakeBodyPartConfig>().AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeBody>().AsCached();
            var snakeInstance = Container.InstantiatePrefabForComponent<SnakeConfig>(snake);
            Container.Bind<SnakeConfig>().FromInstance(snakeInstance).AsSingle();

            Container.Bind<SnakeCollisionDetector>().FromComponentOn(snakeInstance.gameObject).AsSingle();

            Container.BindInterfacesTo<CreateSnakeBodyPart>().AsSingle();

            Container.Bind<BaseSnakeMove>().To<Walk>().AsCached();
        }
    }
}