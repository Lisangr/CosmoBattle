using UnityEngine;
public class ParallaxChooser : MonoBehaviour
{
    public GameObject[] bgPrefab;

    void Start()
    {
        int i = Random.Range(0, bgPrefab.Length);
        bgPrefab[i].SetActive(true);
    }
}  