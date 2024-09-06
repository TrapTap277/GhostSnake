using UnityEngine;

namespace _Scripts.Snake.Eat
{
    public class SnakeEat : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Food.Food>() != null)
                other.gameObject.GetComponent<Food.Food>().PlayAnimationAndDestroy();
        }
    }
}