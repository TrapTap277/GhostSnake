using System;
using _Scripts.Snake.MoveLogic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Scripts.Snake.Body
{
    public class CreateSnakeBodyPart : IInitializable, IDisposable
    {
        private readonly SnakeBodyPartConfig _snakeBodyPartConfig;

        private Vector2 _defaultPos;

        public CreateSnakeBodyPart(SnakeBodyPartConfig snakeBodyPartConfig)
        {
            _snakeBodyPartConfig = snakeBodyPartConfig;
        }

        public void Create()
        {
            for (var i = 0; i < _snakeBodyPartConfig.BodySize * 10; i++) SetAndAddDefaultPosition(i);

            for (var i = 0; i < _snakeBodyPartConfig.BodySize; i++) CreateBodyPart(i);
        }

        private void AddNewPart()
        {
            var snakeConfig = Object.FindObjectOfType<SnakeConfig>();

            if (_snakeBodyPartConfig.SnakeMovePositionList.Count > 0)
            {
                var lastPartPosition = snakeConfig.SnakeTransform;
                _defaultPos = -lastPartPosition.transform.position;
            }
            else
            {
                _defaultPos = new Vector2(10, 10);
            }

            _snakeBodyPartConfig.SnakeMovePositionList.Add(_defaultPos);
            CreateBodyPart(_snakeBodyPartConfig.SnakeBodyParts.Count);
        }

        private void CreateBodyPart(int i)
        {
            var snakeBodyPart =
                Object.Instantiate(_snakeBodyPartConfig.SnakeBodyPrefab, _defaultPos, Quaternion.identity);
            snakeBodyPart.name = "SnakeBody_" + i;
            _snakeBodyPartConfig.SnakeBodyParts.Add(snakeBodyPart);
        }

        private void SetAndAddDefaultPosition(int i)
        {
            _defaultPos = new Vector2(10,
                10 - (i == 0
                    ? _snakeBodyPartConfig.DistanceToFirstPart
                    : i * _snakeBodyPartConfig.DistanceBetweenParts));
            _snakeBodyPartConfig.SnakeMovePositionList.Add(_defaultPos);
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