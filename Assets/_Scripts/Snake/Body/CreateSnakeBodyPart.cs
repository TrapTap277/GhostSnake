using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Scripts.Snake.Body
{
    public class CreateSnakeBodyPart : IInitializable, IDisposable
    {
        private readonly SnakeBodyPartConfig _snakeBodyPartConfig;

        public CreateSnakeBodyPart(SnakeBodyPartConfig snakeBodyPartConfig)
        {
            _snakeBodyPartConfig = snakeBodyPartConfig;
        }

        public void Create()
        {
            for (var i = 0; i < _snakeBodyPartConfig.BodySize * 10; i++)
            {
                SetAndAddDefaultPosition(i);
            }

            for (var i = 0; i < _snakeBodyPartConfig.BodySize; i++)
            {
                CreateBodyPart(i);
            }
        }

        private void AddNewPart()
        {
            Debug.LogWarning("Created new");

            Vector2 newPartPosition;

            if (_snakeBodyPartConfig.SnakeMovePositionList.Count > 0)
            {
                Vector2 lastPartPosition = _snakeBodyPartConfig.SnakeMovePositionList[^1];
                newPartPosition = lastPartPosition - new Vector2(0, _snakeBodyPartConfig.DistanceBetweenParts);
            }
            else
            {
                newPartPosition = new Vector2(10, 10); 
            }

            _snakeBodyPartConfig.SnakeMovePositionList.Add(newPartPosition);

            CreateBodyPart(_snakeBodyPartConfig.SnakeBodyParts.Count); 
        }

        private void CreateBodyPart(int i)
        {
            var snakeMovePos =
                _snakeBodyPartConfig
                    .SnakeMovePositionList[i]; 
            var position = new Vector3(snakeMovePos.x, snakeMovePos.y, 0);
            var snakeBodyPart = Object.Instantiate(_snakeBodyPartConfig.SnakeBodyPrefab, position, Quaternion.identity);
            snakeBodyPart.name = "SnakeBody_" + i;
            _snakeBodyPartConfig.SnakeBodyParts.Add(snakeBodyPart);
        }

        private void SetAndAddDefaultPosition(int i)
        {
            var defaultPos = new Vector2(10,
                10 - (i == 0
                    ? _snakeBodyPartConfig.DistanceToFirstPart
                    : i * _snakeBodyPartConfig.DistanceBetweenParts));
            _snakeBodyPartConfig.SnakeMovePositionList.Add(defaultPos);
        }

        public void Initialize()
        {
            Food.Food.OnDied += AddNewPart;
        }

        public void Dispose()
        {
            Food.Food.OnDied -= AddNewPart;
        }
    }
}