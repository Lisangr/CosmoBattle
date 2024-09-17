
using UnityEngine;

public class NexDialogue : MonoBehaviour
{
    public GameObject current;
    public GameObject next;

    public void OnClick()
    {
        //if (Time.timeScale == 1f)
        //{
            current.SetActive(false);
            next.SetActive(true);
        //}
    }
}
