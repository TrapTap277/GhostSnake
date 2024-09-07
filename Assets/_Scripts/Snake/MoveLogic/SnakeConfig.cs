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

        public Shifting Shifting;
        public Walk Walk;
        public Run Run;

        private GameObject _snakeBodyPrefab;

        [Inject]
        private void Construct(SnakeBody snakeBody)
        {
            SnakeBody = snakeBody;
        }

        public void InitMoveBehaviours()
        {
            GetTransform();

            Shifting = new Shifting(this);
            Run = new Run(this);
            Walk = new Walk(this);
        }

        private void GetTransform()
        {
            SnakeTransform = gameObject.GetComponent<Transform>();
        }
    }
}