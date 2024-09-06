using System;
using System.Collections.Generic;
using _Scripts.Installers;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Scripts.Food
{
    public class FoodSpawner : IInitializable, IDisposable
    {
        private readonly GameObject _food;
        private readonly Tilemap _tileMap;

        private readonly int _numberOfObjectsToSpawn;

        private readonly GridGetPosition _gridGetPosition;

        public FoodSpawner(GameObject food, Tilemap tileMap)
        {
            _food = food;
            _tileMap = tileMap;

            _gridGetPosition = new GridGetPosition(tileMap);
            
            _numberOfObjectsToSpawn = 1;
        }

        public void Initialize()
        {
            BootstrapInjector.OnInitialized += SpawnFood;
            Food.OnDied += SpawnFood;
        }

        private List<Vector3Int> GetAvailablePositions()
        {
            var availablePositions = _gridGetPosition.GetAvailablePositions();
            return availablePositions;
        }

        private void SpawnFood()
        {
            Debug.LogWarning("1");

            var availablePositions = GetAvailablePositions();

            Debug.LogError("spawn");

            for (var i = 0; i < _numberOfObjectsToSpawn; i++)
            {
                if (availablePositions.Count == 0)
                {
                    Debug.LogWarning("There are no positions for spawn!");
                    break;
                }

                Debug.LogError("spawn2");


                var randomIndex = Random.Range(0, availablePositions.Count);
                Debug.LogError("spawn3");

                var spawnPosition = availablePositions[randomIndex];
                Debug.LogError("spawn4");

                Object.Instantiate(_food, _tileMap.GetCellCenterWorld(spawnPosition), Quaternion.identity);
                Debug.LogError("spawn5");

                availablePositions.RemoveAt(randomIndex);
                Debug.LogError("spawn6");
            }
        }

        public void Dispose()
        {
            BootstrapInjector.OnInitialized -= SpawnFood;
            Food.OnDied -= SpawnFood;
        }
    }
}