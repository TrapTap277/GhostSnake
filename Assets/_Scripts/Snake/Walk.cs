using UnityEngine;

namespace _Scripts.Snake
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
