using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisin : MonoBehaviour
{    
    [SerializeField] private List<string> counterNames = new List<string>();
    [SerializeField] private GameObject winPanel;
    public int score;

    private Dictionary<string, int> counterValues = new Dictionary<string, int>();

    private void Start()
    {
        winPanel.SetActive(false);
        InitializeCounters();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objectName = collision.gameObject.name;

        if (counterValues.ContainsKey(objectName))
        {
            counterValues[objectName]++;
            CheckWinCondition();
        }
    }

    private void InitializeCounters()
    {
        foreach (string counterName in counterNames)
        {
            counterValues[counterName] = 0;
        }
    }

    private void CheckWinCondition()
    {
        foreach (KeyValuePair<string, int> entry in counterValues)
        {
            if (entry.Value < score)
            {
                return;
            }
        }

        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
}