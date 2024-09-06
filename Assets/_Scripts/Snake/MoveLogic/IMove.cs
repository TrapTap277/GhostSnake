using UnityEngine;

namespace _Scripts.Snake.MoveLogic
{
    public interface IMove
    {
        void Move(Vector2 direction);
    }
}