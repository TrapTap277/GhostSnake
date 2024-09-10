using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Scripts.Snake.Body
{
    public class SnakeBodyPartConfig
    {
        public List<Vector2> SnakeMovePositionList { get; } = new List<Vector2>();
        public List<GameObject> SnakeBodyParts { get; } = new List<GameObject>();
        public int BodySize { get; }
        public GameObject SnakeBodyPrefab { get; }

        public float DistanceBetweenParts { get; }
        public float DistanceToFirstPart { get; }
        public float SmoothSpeed { get; }

        public Vector2 GridPos { get; private set; } = Vector2.zero;

        public SnakeBodyPartConfig([Inject(Id = "BodySize")] int bodySize,
            [Inject(Id = "SnakeBody")] GameObject snakeBodyPrefab,
            [Inject(Id = "DistanceBetweenParts")] float distanceBetweenParts,
            [Inject(Id = "DistanceToFirstPart")] float distanceToFirstPart,
            [Inject(Id = "SmoothSpeed")] float smoothSpeed)
        {
            BodySize = bodySize;
            SnakeBodyPrefab = snakeBodyPrefab;
            DistanceBetweenParts = distanceBetweenParts;
            DistanceToFirstPart = distanceToFirstPart;
            SmoothSpeed = smoothSpeed;
        }

        public void SetGridPos(Vector2 gridPos)
        {
            GridPos = gridPos;
        }
    }
}