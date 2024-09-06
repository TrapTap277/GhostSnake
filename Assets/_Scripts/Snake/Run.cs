using UnityEngine;

namespace _Scripts.Snake
{
    public class Run : BaseSnakeMove
    {
        private const float MOVE_SPEED = 60;
        
        public Run(Transform playerTransform) : base(playerTransform)
        {
            MoveSpeed = MOVE_SPEED;
        }
    }
}