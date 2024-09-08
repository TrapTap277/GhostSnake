using UnityEngine;

namespace _Scripts.Snake.Body
{
    public class ResetBody
    {
        private readonly SnakeBodyPartConfig _snakeBodyPartConfig;

        public ResetBody(SnakeBodyPartConfig snakeBodyPartConfig)
        {
            _snakeBodyPartConfig = snakeBodyPartConfig;
        }

        public void Reset()
        {
            foreach (var part in _snakeBodyPartConfig.SnakeBodyParts)
            {
                Object.Destroy(part);
            }
        }
    }
}