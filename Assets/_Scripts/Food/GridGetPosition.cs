using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _Scripts.Food
{
    public class GridGetPosition
    {
        private readonly Tilemap _tilemap;

        private Vector2Int _spawnAreaMin;
        private Vector2Int _spawnAreaMax;

        public GridGetPosition(Tilemap tilemap)
        {
            _tilemap = tilemap;

            _spawnAreaMin = new Vector2Int(-10, -5);
            _spawnAreaMax = new Vector2Int(10, 5);
        }

        public List<Vector3Int> GetAvailablePositions()
        {
            var availablePositions = new List<Vector3Int>();

            for (var x = _spawnAreaMin.x; x <= _spawnAreaMax.x; x++)
            for (var y = _spawnAreaMin.y; y <= _spawnAreaMax.y; y++)
            {
                var position = new Vector3Int(x, y, 0);
                if (_tilemap.GetTile(position) == null) availablePositions.Add(position);
            }

            return availablePositions;
        }
    }
}