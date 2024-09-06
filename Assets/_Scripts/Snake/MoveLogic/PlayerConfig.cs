using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class PlayerConfig : MonoBehaviour
    {
        public const string SHIFTING_ID = "Shifting";
        public const string MOVE_ID = "Move";
        public const string RUN_ID = "Run";

        public Shifting Shifting;
        public Walk Walk;
        public Run Run;

        private Transform _snakeTransform;

        public void InitMoveBehaviours()
        {
            GetTransform();

            Shifting = new Shifting(_snakeTransform);
            Run = new Run(_snakeTransform);
            Walk = new Walk(_snakeTransform);
        }

        private void GetTransform()
        {
            _snakeTransform = gameObject.GetComponent<Transform>();
        }
    }
}