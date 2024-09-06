using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class Shifting : BaseSnakeMove
    {
        private const float MOVE_SPEED = 20;

        public Shifting(Transform playerTransform) : base(playerTransform)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}