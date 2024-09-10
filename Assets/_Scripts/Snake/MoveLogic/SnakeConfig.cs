using _Scripts.Snake.Body;
using UnityEngine;
using Zenject;

namespace _Scripts.Snake.MoveLogic
{
    public class SnakeConfig : MonoBehaviour
    {
        public Transform SnakeTransform { get; private set; }
        public SnakeBody SnakeBody { get; private set; }

        public const string SHIFTING_ID = "Shifting";
        public const string MOVE_ID = "Move";
        public const string RUN_ID = "Run";

        [Inject]
        private void Construct(SnakeBody snakeBody)
        {
            SnakeBody = snakeBody;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            SnakeTransform = GetComponent<Transform>();
        }
    }
}