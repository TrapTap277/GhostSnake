using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace _Scripts.Installers
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private Tilemap tilemap;

        public override void InstallBindings()
        {
            Container.BindInstance(tilemap).AsTransient();
            Debug.LogWarning("Binded " + tilemap);
        }
    }
}