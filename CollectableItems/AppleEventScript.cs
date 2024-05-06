using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleEventScript : MonoBehaviour
{
    public GameObject particleSystem;
    public delegate void DeathAction();
    public static event DeathAction OnAppleDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);

        if (collision.CompareTag("Player"))
        {
            OnAppleDeath?.Invoke();
            Destroy(gameObject);
            
        }
    }
}
