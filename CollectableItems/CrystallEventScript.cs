using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallEventScript : MonoBehaviour
{
    public GameObject particleSystem;
    public delegate void DeathAction();
    public static event DeathAction OnCrystallDeath;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnCrystallDeath?.Invoke();
        }
    }
}
