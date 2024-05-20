using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (!PauseActivator.isPaused)
        {
            transform.Translate(Vector2.left * speed);             
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage;
            Destroy(gameObject);            
        }
    }
}
