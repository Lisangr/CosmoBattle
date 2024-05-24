using UnityEngine;

public class Destroer : MonoBehaviour
{
    private float lifeTime = 20f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
