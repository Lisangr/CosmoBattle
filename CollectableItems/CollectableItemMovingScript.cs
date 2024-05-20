using UnityEngine;

public class CollectableItemMovingScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if (!PauseActivator.isPaused)
        {
            transform.Translate(Vector2.left * speed);
        }
    }
}
