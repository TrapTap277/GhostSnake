using UnityEngine;

namespace _Scripts.Snake.Body
{
    public class MoveAndRotateBodyPart
    {
        private readonly SnakeBodyPartConfig _snakeBodyPartConfig;

        public MoveAndRotateBodyPart(SnakeBodyPartConfig snakeBodyPartConfig)
        {
            _snakeBodyPartConfig = snakeBodyPartConfig;
        }

        public void UpdateBodyPartsWithDistance()
        {
            _snakeBodyPartConfig.SnakeMovePositionList.Insert(0, _snakeBodyPartConfig.GridPos);

            if (_snakeBodyPartConfig.SnakeBodyParts.Count == 0) return;

            var headPosition = new Vector3(_snakeBodyPartConfig.GridPos.x, _snakeBodyPartConfig.GridPos.y, 0);

            for (var i = 0; i < _snakeBodyPartConfig.SnakeBodyParts.Count; i++)
            {
                var targetPosition = DeterminateMove(i, headPosition);

                MoveBodyPartWithLerp(i, targetPosition);

                RotateBodyPart(i, headPosition);
            }

            while (_snakeBodyPartConfig.SnakeMovePositionList.Count > _snakeBodyPartConfig.BodySize * 10)
                _snakeBodyPartConfig.SnakeMovePositionList.RemoveAt(
                    _snakeBodyPartConfig.SnakeMovePositionList.Count - 1);
        }

        private void MoveBodyPartWithLerp(int i, Vector3 targetPosition)
        {
            _snakeBodyPartConfig.SnakeBodyParts[i].transform.position = Vector3.Lerp(
                _snakeBodyPartConfig.SnakeBodyParts[i].transform.position, targetPosition,
                Time.deltaTime * _snakeBodyPartConfig.SmoothSpeed);
        }

        private Vector3 DeterminateMove(int i, Vector3 headPosition)
        {
            Vector3 targetPosition;
            if (i == 0)
            {
                var direction = (_snakeBodyPartConfig.SnakeBodyParts[i].transform.position - headPosition).normalized;
                targetPosition = headPosition + direction * _snakeBodyPartConfig.DistanceToFirstPart;
            }
            else
            {
                var previousPartPosition = _snakeBodyPartConfig.SnakeBodyParts[i - 1].transform.position;
                var direction = (previousPartPosition - _snakeBodyPartConfig.SnakeBodyParts[i].transform.position)
                    .normalized;
                targetPosition = previousPartPosition - direction * _snakeBodyPartConfig.DistanceBetweenParts;
            }

            return targetPosition;
        }

        private void RotateBodyPart(int i, Vector3 headPosition)
        {
            if (i < _snakeBodyPartConfig.SnakeBodyParts.Count - 1)
            {
                var nextPartPosition =
                    i == 0 ? headPosition : _snakeBodyPartConfig.SnakeBodyParts[i + 1].transform.position;
                var direction = (nextPartPosition - _snakeBodyPartConfig.SnakeBodyParts[i].transform.position)
                    .normalized;
                if (direction != Vector3.zero)
                {
                    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    var targetRotation = Quaternion.Euler(0, 0, angle);
                    _snakeBodyPartConfig.SnakeBodyParts[i].transform.rotation = Quaternion.Slerp(
                        _snakeBodyPartConfig.SnakeBodyParts[i].transform.rotation, targetRotation,
                        Time.deltaTime * _snakeBodyPartConfig.SmoothSpeed);
                }
            }
        }
    }
}