using System;
using UnityEngine;

namespace _Scripts.Food
{
    public class Food : MonoBehaviour
    {
        private static readonly int IsEaten = Animator.StringToHash("IsEaten");

        public static event Action OnDied;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimationAndDestroy()
        {
            _animator.SetBool(IsEaten, true);
        }

        public void DestroyFood()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnDied?.Invoke();
        }
    }
}