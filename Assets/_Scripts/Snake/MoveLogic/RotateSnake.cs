using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class RotateSnake
    {
        private readonly Transform _playerTransform;

        public RotateSnake(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void RotateObject(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                angle -= 90;
                _playerTransform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}