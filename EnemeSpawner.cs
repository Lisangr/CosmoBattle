using UnityEngine;

public class EnemeSpawner : MonoBehaviour
{
    public GameObject[] StarVariants;
    public float startTimeBtwSpawn = 2f;
    public float decreaseTime = 0.05f;
    public float minTime = 1.4f;

    private float timeBtwSpawn;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, StarVariants.Length);
            Instantiate(StarVariants[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

    }
}