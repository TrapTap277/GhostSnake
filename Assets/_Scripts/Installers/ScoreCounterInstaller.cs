using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class ScoreCounterInstaller : MonoInstaller
    {
        [SerializeField] private int score = 10;

        public override void InstallBindings()
        {
            Container.Bind<int>().WithId("DefaultScore").FromInstance(score).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter.ScoreCounter>().AsCached();
        }
    }
}