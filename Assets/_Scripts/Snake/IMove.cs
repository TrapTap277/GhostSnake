using UnityEngine;

namespace _Scripts.Snake
{
    public interface IMove
    {
        void Move(Vector2 direction);
    }
}