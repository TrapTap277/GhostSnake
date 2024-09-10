using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class BaseSnakeMove : IMove
    {
        protected float MoveSpeed;

        private static Vector2Int _gridPos;

        private static Vector2 _moveDirection;

        private readonly RotateSnake _rotateSnake;

        private readonly SnakeConfig _context;

        private static SnakeState _currentSnakeState;

        private Vector3 _targetPosition;

        protected BaseSnakeMove(SnakeConfig context)
        {
            _moveDirection = Vector2.zero;
            _context = context;

            _rotateSnake = new RotateSnake(_context.SnakeTransform);

            SetSnakeState(SnakeState.Alive);

            SetStartPosition();
        }

        public void Move(Vector2 direction)
        {
            if (_currentSnakeState == SnakeState.Alive)
            {
                direction = NormalizeDirection(direction);

                if (direction != Vector2.zero && _moveDirection != -direction)
                {
                    SetDirection(direction);
                    RotateSnake(direction);
                }

                MoveSnake();
            }

            if (_currentSnakeState == SnakeState.Died) _context.SnakeBody.SetGridPos(_context.SnakeTransform.position);
        }

        public void SetSnakeState(SnakeState currentSnakeState)
        {
            _currentSnakeState = currentSnakeState;
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

            var position = _context.SnakeTransform.position;
            _context.SnakeBody.SetGridPos(position);
            position += movement;
            _context.SnakeTransform.position = position;
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

    public enum SnakeState
    {
        None,
        Alive,
        Died
    }
}