using System;
using _Scripts.Snake.Died;
using UnityEngine;
using Zenject;

namespace _Scripts.Snake.Eat
{
    public class SnakeCollisionDetector : MonoBehaviour
    {
        private const string OBSTACLE = "Obstacle";

        private SnakeDied _snakeDied;

        [Inject]
        private void Construct(SnakeDied snakeDied)
        {
            _snakeDied = snakeDied; 
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Food.Food>() != null)
                other.gameObject.GetComponent<Food.Food>().PlayAnimationAndDestroy();

            if (other.CompareTag(OBSTACLE))
            {
                _snakeDied.Died();
                Debug.LogWarning("Game over!");
            }
        }
    }
}