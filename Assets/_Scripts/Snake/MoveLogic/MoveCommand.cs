using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public class MoveCommand
    {
        public void Execute(IMove move, Vector2 direction)
        {
            move.Move(direction);
        }
    }
}