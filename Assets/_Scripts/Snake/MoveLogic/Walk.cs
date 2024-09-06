using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class Walk : BaseSnakeMove
    {
        private const float MOVE_SPEED = 40f;
        
        public Walk(Transform playerTransform) : base(playerTransform)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}
