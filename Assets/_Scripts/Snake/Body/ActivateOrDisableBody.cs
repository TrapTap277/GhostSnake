using System.Collections;
using UnityEngine;

namespace _Scripts.Snake.Body
{
    public class ActivateOrDisableBody : MonoBehaviour
    {
        private CircleCollider2D _collider2D;
        private const int TIME_TO_ACTIVATION = 3;

        private void Awake()
        {
            _collider2D = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            if (gameObject.CompareTag("Obstacle"))
            {
                SetActive(false);
                StartCoroutine(Activate());
            }
        }
        
        private IEnumerator Activate()
        {
            yield return new WaitForSeconds(TIME_TO_ACTIVATION);
            SetActive(true);
        }

        private void SetActive(bool change)
        {
            _collider2D.enabled = change;
        }

        private void OnDisable()
        {
            Destroy(gameObject);
        }
    }
}