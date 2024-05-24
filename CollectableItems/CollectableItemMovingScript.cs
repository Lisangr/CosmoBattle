using UnityEngine;

public class CollectableItemMovingScript : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (!PauseActivator.isPaused && !TimerBeforeAdsYG.inPausing)
        {
            transform.Translate(Vector2.left * speed);
        }
    }
}
