using UnityEngine;
using Zenject;

namespace _Scripts.Snake.Body
{
    public class SnakeBodySpawner : MonoBehaviour
    {
        private SnakeBody _snakeBody;

        [Inject]
        private void Construct(SnakeBody snakeBody)
        {
            _snakeBody = snakeBody;
        }

        private void Start()
        {
            _snakeBody.Create();
        }
    }
}