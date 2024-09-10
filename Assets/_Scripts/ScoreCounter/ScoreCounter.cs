using System;
using _Scripts.Music;
using UnityEngine;
using Zenject;

namespace _Scripts.ScoreCounter
{
    public class ScoreCounter : IInitializable
    {
        public static event Action<MusicType> OnSetMusicType;
        public event Action<int> OnScoreChanged;
        public event Action OnSetScoreOnSnake;

        public const int DEFAULT_SCORE = 10;

        private const string HIGH_SCORE_KEY = "Score";

        private int _score;

        private int Score
        {
            get => _score;
            set
            {
                _score = Mathf.Max(value, 0);

                if (value > GetHighestScore()) SetHighestScore();

                ChangeScore();
            }
        }

        public void Initialize()
        {
            OnScoreChanged?.Invoke(0);
        }

        public void AddScore()
        {
            Score += DEFAULT_SCORE;
        }

        public int GetHighestScore()
        {
            var high = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
            return high;
        }

        public void ResetScore()
        {
            Score = 0;
        }

        private void SetHighestScore()
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, Score);
            OnSetMusicType?.Invoke(MusicType.Victory);
        }

        private void ChangeScore()
        {
            OnScoreChanged?.Invoke(_score);
            OnSetScoreOnSnake?.Invoke();
        }
    }
}