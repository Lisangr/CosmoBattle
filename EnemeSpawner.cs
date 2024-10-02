/*using UnityEngine;

public class EnemeSpawner : MonoBehaviour
{
    public GameObject[] StarVariants;
    public float startTimeBtwSpawn = 2f;
    public float decreaseTime = 0.05f;
    public float minTime = 1.4f;
    public Vector2 baseResolution = new Vector2(1920, 1080); // ������� ���������� (��������, Full HD)

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
            GameObject spawnedObject = Instantiate(StarVariants[rand], transform.position, Quaternion.identity);

            // �������� ������� ���������� ������
            Vector2 currentResolution = new Vector2(Screen.width, Screen.height);

            // ��������� ����������� �������� ���������� � ��������
            Vector2 resolutionRatio = new Vector2(currentResolution.x / baseResolution.x, currentResolution.y / baseResolution.y);

            // ������������� ������� ������� �� ������ ����������� ����������
            spawnedObject.transform.localScale = new Vector3(resolutionRatio.x, resolutionRatio.y, 1f);

            // ���������� ������ ������
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
*/



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