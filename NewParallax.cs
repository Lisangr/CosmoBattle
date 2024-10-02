using UnityEngine;
using UnityEngine.UI;

public class NewParallax : MonoBehaviour
{
    private RawImage rawImage;
    private float distanceX;
    private float distanceY;

    public float speedX = 0.2f; // Скорость прокрутки по оси X
    public float speedY = 0.1f; // Скорость прокрутки по оси Y

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        if (!PauseActivator.isPaused && !TimerBeforeAdsYG.inPausing)
        {
            distanceX += Time.deltaTime * speedX;
            distanceY += Time.deltaTime * speedY;
            rawImage.uvRect = new Rect(distanceX, distanceY, rawImage.uvRect.width, rawImage.uvRect.height); // Прокрутка по XY
        }
    }
}

/*using UnityEngine;

public class NewParallax : MonoBehaviour
{
    private Material mat;
    private float distance;

    public float speed = 0.2f;

    void Start()
    {
        Time.timeScale = 1f;
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        if (!PauseActivator.isPaused && !TimerBeforeAdsYG.inPausing)
        {
            distance += Time.deltaTime * speed;
            mat.SetTextureOffset("_MainTex", Vector2.right * distance);
        }
    }
}
*/