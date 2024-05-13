using UnityEngine;
using YG;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public delegate void DeathAction();
    public static event DeathAction OnPlayerDeath;

    public float offset;
    public float speedY;
    public float maxHeight;
    public float minHeight;
    public int health;
    public GameObject particleSystem;
    public Joystick joystick;
    public Image hearts;
    private Vector2 targetPos;
    public GameObject defeatPanel;
    private int AdID = 1;
    public static bool isRevarded;
    public GameObject endGameScreen;
    public TMP_Text healthText;
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        HealthPotionEventScript.LetsHealThis += DoHealingPlayer;
    }

    public void Rewarded(int id)
    {
        if (id == AdID)
            AddHealth();

        gameObject.SetActive(true);
        defeatPanel.SetActive(false);
        Time.timeScale = 1.0f;
        isRevarded = true;

        YandexGame.RewardVideoEvent -= Rewarded;
    }

    private void DoHealingPlayer()
    {
        if (health < 5)
        {       
            health ++;                      
        }
    }  

    private void AddHealth()
    {
        health = 5;
    }

    private void OnDisable()
    {                
        HealthPotionEventScript.LetsHealThis -= DoHealingPlayer;
    }
    private void Start()
    {
        healthText.text = health.ToString();
    }
    private void Update()
    {
        healthText.text = health.ToString();

        if (health <= 0)
        {
            OnPlayerDeath?.Invoke();
            Time.timeScale = 0f;
            gameObject.SetActive(false);

            if (!isRevarded)
            {
                defeatPanel.SetActive(true);
            }
            else
            {
                endGameScreen.SetActive(true);
            }
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

        float joystickInput = joystick.Direction.y;

        if (JoystickController.onMobile && (joystickInput > 0 && transform.position.y < maxHeight))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + offset);
        }
        if (JoystickController.onMobile && (joystickInput < 0 && transform.position.y > minHeight))
        {
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