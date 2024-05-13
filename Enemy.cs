using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeathAction();
    public static event DeathAction DestroyHealthImage;

    public int damage = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage;
            DestroyHealthImage?.Invoke();
            Destroy(gameObject);
        }
    }
}
