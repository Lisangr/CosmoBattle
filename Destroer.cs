using UnityEngine;

public class Destroer : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
