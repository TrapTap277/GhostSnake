using _Scripts.Food;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class FoodInstaller : MonoInstaller
    {
        [SerializeField] private GameObject foodPrefab;

        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("Food").FromInstance(foodPrefab).AsCached();
            Container.BindInterfacesTo<FoodSpawner>().AsSingle();
        }
    }
}