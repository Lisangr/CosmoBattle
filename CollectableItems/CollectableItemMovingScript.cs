
using UnityEngine;

public class CollectableItemMovingScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed);
    }
}
