using UnityEngine;
using TMPro;
using YG;
using System;

public class Timer : MonoBehaviour
{
    //private LeaderboardYG leaderboardYG;
    public TextMeshProUGUI timerText;
    public bool isRunning = false;
    public float currentTime = 0f;
    private float lastTime;

    private void Start()
    {
        StartStopwatch();
        LoadSaveTimerFromCloud();
    }
    private void OnEnable()
    {
        Player.OnPlayerDeath += StopAndSaveTimer;
    }

    private void StopAndSaveTimer()
    {
        isRunning = false;
        Time.timeScale = 0f;        

        if (currentTime >= lastTime)
        {
            AddTimeLeaderboard();
            SaveTimer();
        }
    }

    private void SaveTimer()
    {
        YandexGame.savesData.timeOnUnlimitedLevel = currentTime;
        YandexGame.SaveProgress();
    }
    public void LoadSaveTimerFromCloud()
    {
        lastTime = YandexGame.savesData.timeOnUnlimitedLevel;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= StopAndSaveTimer;
    }
    public void AddTimeLeaderboard()
    {
        YandexGame.NewLBScoreTimeConvert("Time", currentTime);
    }
    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
        if (!isRunning && Player.isRevarded == true)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }

    public void StartStopwatch()
    {
        isRunning = !isRunning;
    }

    public void ResetStopwatch()
    {
        currentTime = 0f;
        DisplayTime(currentTime);
    }

    private void DisplayTime(float timeToDisplay)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
    }
}
