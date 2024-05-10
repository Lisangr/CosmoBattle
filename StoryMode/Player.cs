using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class Player : MonoBehaviour
{
    public float offset;
    public float speedY;
    public float maxHeight;
    public float minHeight;
    public int health;
    public GameObject particleSystem;
    public Joystick joystick;

    private Vector2 targetPos;


    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speedY * Time.deltaTime);

        //для компьютеров
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight) 
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + offset);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - offset);
        }

        // Для джойстика
        float joystickInput = joystick.Direction.y;

        if (joystickInput > 0 && transform.position.y < maxHeight)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + offset);
        }
        if (joystickInput < 0 && transform.position.y > minHeight)
        {
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - offset);
        }
    }
}
    
    /*
      стрельба вправо
    public float offset;
    public float speedY;
    public float maxHeight;
    public float minHeight;
    public int health;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private Vector2 targetPos;

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speedY * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + offset);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - offset);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new bullet object
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get the bullet's Rigidbody component
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Add force to the bullet in the right direction
            bulletRigidbody.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        }
    } /*
    Стрельбав направлении курсора
        public float offset;
    public float speedY;
    public float maxHeight;
    public float minHeight;
    public int health;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private Vector2 targetPos;

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speedY * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + offset);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - offset);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new bullet object
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get the bullet's Rigidbody component
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Calculate the direction the bullet should move in
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            // Add force to the bullet in the calculated direction
            bulletRigidbody.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        }
    }
    /*
      */