using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private int minVariants;
    [SerializeField] private int maxVariants;

    public GameObject[] TargetPrefabs;
    public GameObject[] TargetPrefabsOnPauseMenu;
    public Transform TargetPanel;
    public Transform TargetPausePanel;

    private List<GameObject> spawnedTargets = new List<GameObject>();
    // ...
    public List<string> TargetNames { get; private set; } = new List<string>();
    // ...
    void Awake()
    {
        int numOfTargetsToSpawn = Random.Range(minVariants, maxVariants);
        List<int> availableIndexes = new List<int>(Enumerable.Range(0, TargetPrefabs.Length));

        for (int i = 0; i < numOfTargetsToSpawn; i++)
        {
            if (availableIndexes.Count == 0)
            {
                break;
            }

            int randomIndex = Random.Range(0, availableIndexes.Count);
            int targetIndex = availableIndexes[randomIndex];
            availableIndexes.RemoveAt(randomIndex);

            GameObject targetInstance = Instantiate(TargetPrefabs[targetIndex], transform);
            targetInstance.transform.SetParent(TargetPanel, false);
            spawnedTargets.Add(targetInstance);

            if (TargetPrefabsOnPauseMenu.Length > targetIndex)
            {
                GameObject targetPauseInstance = Instantiate(TargetPrefabsOnPauseMenu[targetIndex], transform);
                targetPauseInstance.transform.SetParent(TargetPausePanel, false);
                spawnedTargets.Add(targetPauseInstance);
            }
        }
        // ...

        // Получение имен объектов из TargetPanel
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject targetObject in targetObjects)
        {
            string objectName = targetObject.name;
            TargetNames.Add(objectName);
        }
    }
}