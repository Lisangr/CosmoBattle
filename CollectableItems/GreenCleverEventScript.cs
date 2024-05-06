using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCleverEventScript : MonoBehaviour
{
    public GameObject particleSystem;
    public delegate void DeathAction();
    public static event DeathAction OnGreenCleverDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnGreenCleverDeath?.Invoke();
        }
    }
}
