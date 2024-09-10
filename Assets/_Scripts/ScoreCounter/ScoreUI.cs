using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.ScoreCounter
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI sceneCurrentScoreText;
        [SerializeField] private TextMeshProUGUI sceneBestScoreText;

        private static SnakeText _snakeScoreText;

        private ScoreCounter _scoreCounter;

        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        public void SetSnakeText(SnakeText text)
        {
            _snakeScoreText = text;
        }

        private void SetScoreOnSnakeOnSnake()
        {
            _snakeScoreText.ChangeSnakeText(ScoreCounter.DEFAULT_SCORE);
        }

        private void ScoreChanged(int score)
        {
            sceneBestScoreText.text = $"High Score: {_scoreCounter.GetHighestScore()}";
            sceneCurrentScoreText.text = $"Current Score: {score}";
        }

        private void OnEnable()
        {
            _scoreCounter.OnScoreChanged += ScoreChanged;
            _scoreCounter.OnSetScoreOnSnake += SetScoreOnSnakeOnSnake;
        }

        private void OnDisable()
        {
            _scoreCounter.OnScoreChanged -= ScoreChanged;
            _scoreCounter.OnSetScoreOnSnake -= SetScoreOnSnakeOnSnake;
        }
    }
}