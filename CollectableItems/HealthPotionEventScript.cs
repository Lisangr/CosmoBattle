using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionEventScript : MonoBehaviour
{
    public GameObject particleSystem;
    public delegate void DeathAction();
    public static event DeathAction OnHealthPotionDeath;
    public static event DeathAction LetsHealThis;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            OnHealthPotionDeath?.Invoke();
            LetsHealThis?.Invoke();
            Destroy(gameObject);
            
        }
    }
}
