using System;
using TMPro;
using UnityEngine;

public class TimerBack : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool isRunning = false;
    public float currentTime = 120f;
    public GameObject winScreen;
    private void Start()
    {
        StartStopwatch();
    }
    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            DisplayTime(currentTime);
        }
        if (!isRunning && Player.isRevarded == true)
        {
            currentTime -= Time.deltaTime;
            DisplayTime(currentTime);
        }

        if (currentTime < 0)
        {
            Time.timeScale = 0f;
            currentTime = 0f;
            winScreen.SetActive(true);
        }
    }
    public void StartStopwatch()
    {
        isRunning = !isRunning;
    }
    private void DisplayTime(float timeToDisplay)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }

}
