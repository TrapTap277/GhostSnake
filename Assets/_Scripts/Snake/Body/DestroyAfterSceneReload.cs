using UnityEngine;

namespace _Scripts.Snake.Body
{
    public class DestroyAfterSceneReload : MonoBehaviour
    {
        private void OnDisable()
        {
            Destroy(gameObject);
        }
    }
}