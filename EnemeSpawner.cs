using UnityEngine;

public class EnemeSpawner : MonoBehaviour
{
    public GameObject[] StarVariants;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 2f;

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