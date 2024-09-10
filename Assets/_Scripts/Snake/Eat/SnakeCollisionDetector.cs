using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Snake.Eat
{
    public class SnakeCollisionDetector : MonoBehaviour
    {
        public static event Action OnSnakeDied;

        private const string OBSTACLE = "Obstacle";

        private ScoreCounter.ScoreCounter _scoreCounter;

        [Inject]
        private void Construct(ScoreCounter.ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Food.Food>() != null)
            {
                other.gameObject.GetComponent<Food.Food>().PlayAnimationAndDestroy();
                _scoreCounter.AddScore();
            }

            if (other.CompareTag(OBSTACLE)) OnSnakeDied?.Invoke();
        }
    }
}