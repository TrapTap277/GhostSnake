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
            Container.BindInstance(foodPrefab).AsSingle();
            Container.BindInterfacesTo<FoodSpawner>().AsSingle();
        }
    }
}