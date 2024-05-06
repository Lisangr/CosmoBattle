using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckerCounts : MonoBehaviour
{    
    [SerializeField] private List<string> counterNames = new List<string>();
    [SerializeField] private GameObject winPanel;
    public static int score;
    public int scoreForStatic;
    private Dictionary<string, int> counterValues = new Dictionary<string, int>();

    void Start()
    {
        score = scoreForStatic;

        winPanel.SetActive(false);
        InitializeCounters();

        TargetSpawner targetSpawner = FindObjectOfType<TargetSpawner>();

        foreach (string targetName in targetSpawner.TargetNames)
        {
                string trimmedTargetName = targetName.Substring(0, targetName.IndexOf('P'));
                counterNames.Add(trimmedTargetName);
            Debug.Log("Added to counterNames: " + trimmedTargetName);
        }
        foreach (string counterName in counterNames)
        {
            counterValues[counterName] = 0;
            Debug.Log("Initialized counter for: " + counterName);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objectName = collision.gameObject.name;

        if (counterValues.ContainsKey(objectName))
        {
            counterValues[objectName]++;
            CheckWinCondition();
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by: " + collision.gameObject.name);
        string objectName = collision.gameObject.name;

        if (counterValues.ContainsKey(objectName))
        {
            counterValues[objectName]++;
            CheckWinCondition();
        }
        else
        {
            Debug.Log("No counter found for: " + objectName);
        }
    }

    private void InitializeCounters()
    {
        foreach (string counterName in counterNames)
        {
            counterValues[counterName] = 0;
        }
    }
    /*
    private void CheckWinCondition()
    {
        foreach (KeyValuePair<string, int> entry in counterValues)
        {
            if (entry.Value < scoreForStatic)
            {
                return;
            }
        }

        Time.timeScale = 0;
        winPanel.SetActive(true);
    }*/
    private void CheckWinCondition()
    {
        bool allCountersMet = true;
        foreach (KeyValuePair<string, int> entry in counterValues)
        {
            if (entry.Value < scoreForStatic)
            {
                allCountersMet = false;
                Debug.Log("Counter " + entry.Key + " is not enough: " + entry.Value);
                break;
            }
        }

        if (allCountersMet)
        {
            Debug.Log("Win condition met");
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Win condition not met");
        }
    }
}