using System;
using UnityEngine;

namespace _Scripts.Food
{
    public class Food : MonoBehaviour
    {
        public static event Action OnDied;

        private static readonly int IsEaten = Animator.StringToHash("IsEaten");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimationAndDestroy()
        {
            _animator.SetBool(IsEaten, true);
        }

        public void OnCreatedNewSnakeBody()
        {
            OnDied?.Invoke();
        }

        public void DestroyFood()
        {
            Destroy(gameObject);
        }
    }
}