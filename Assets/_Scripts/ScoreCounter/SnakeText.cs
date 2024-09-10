using System.Collections;
using TMPro;
using UnityEngine;

namespace _Scripts.ScoreCounter
{
    public class SnakeText : MonoBehaviour
    {
        private TextMeshProUGUI _snakeText;

        private void OnEnable()
        {
            _snakeText = gameObject.GetComponent<TextMeshProUGUI>();

            var scoreUI = FindObjectOfType<ScoreUI>();
            scoreUI.SetSnakeText(this);
        }

        public void ChangeSnakeText(int score)
        {
            _snakeText.gameObject.SetActive(true);
            _snakeText.text = $"+{score}";

            StartCoroutine(FadeTextWithTime());
        }

        private IEnumerator FadeTextWithTime()
        {
            yield return new WaitForSeconds(1.5f);
            _snakeText.gameObject.SetActive(false);
        }
    }
}