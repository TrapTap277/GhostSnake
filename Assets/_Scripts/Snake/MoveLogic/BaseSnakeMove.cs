using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public abstract class BaseSnakeMove : IMove
    {
        protected float MoveSpeed;

        private static Vector2Int _gridPos;

        private static Vector2 _moveDirection;

        private readonly RotateSnake _rotateSnake;

        private readonly SnakeConfig _context;

        private Vector3 _targetPosition;

        protected BaseSnakeMove(SnakeConfig context)
        {
            _context = context;

            _rotateSnake = new RotateSnake(_context.SnakeTransform);

            SetStartPosition();
        }

        public void Move(Vector2 direction)
        {
            direction = NormalizeDirection(direction);

            if (direction != Vector2.zero && _moveDirection != -direction)
            {
                SetDirection(direction);
                RotateSnake(direction);
            }

            MoveSnake();
        }

        private void SetDirection(Vector2 direction)
        {
            _moveDirection = direction;
            _gridPos += new Vector2Int((int) direction.x, (int) direction.y);
            _targetPosition = new Vector3(_gridPos.x, _gridPos.y, 0);
        }

        private void RotateSnake(Vector2 direction)
        {
            _rotateSnake?.RotateObject(direction);
        }

        private void MoveSnake()
        {
            var movement = new Vector3(_moveDirection.x, _moveDirection.y, 0) * MoveSpeed * Time.deltaTime;

            _context.SnakeBody.SetGridPos(_context.SnakeTransform.position);
            _context.SnakeTransform.position += movement;
        }

        private void SetStartPosition()
        {
            _gridPos = new Vector2Int(0, 0);
            _targetPosition = new Vector3(_gridPos.x, _gridPos.y, 0);
            _context.SnakeTransform.position = _targetPosition;
        }

        private static Vector2 NormalizeDirection(Vector2 direction)
        {
            return direction.magnitude > 0 ? direction.normalized : Vector2.zero;
        }
    }
}