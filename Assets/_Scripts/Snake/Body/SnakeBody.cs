﻿using UnityEngine;
using Zenject;

namespace _Scripts.Snake.Body
{
    public class SnakeBody : ITickable
    {
        private readonly MoveAndRotateBodyPart _moveAndRotateBodyPart;
        private readonly CreateSnakeBodyPart _createSnakeBodyPart;
        private readonly SnakeBodyPartConfig _snakeBodyPartConfig;
        private readonly ResetBody _resetBody;

        public SnakeBody(SnakeBodyPartConfig snakeBodyPartConfig)
        {
            _snakeBodyPartConfig = snakeBodyPartConfig;
            _moveAndRotateBodyPart = new MoveAndRotateBodyPart(snakeBodyPartConfig);
            _createSnakeBodyPart = new CreateSnakeBodyPart(snakeBodyPartConfig);
            _resetBody = new ResetBody(_snakeBodyPartConfig);
        }

        public void Tick()
        {
            _moveAndRotateBodyPart.UpdateBodyPartsWithDistance();
        }

        public void SetGridPos(Vector2 position)
        {
            _snakeBodyPartConfig.SetGridPos(position);
        }

        public void Create()
        {
            _createSnakeBodyPart.Create();
        }

        public void Reset()
        {
            _resetBody.Reset();
        }
    }
}