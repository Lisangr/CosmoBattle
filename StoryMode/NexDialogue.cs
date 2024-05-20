
using UnityEngine;

public class NexDialogue : MonoBehaviour
{
    public GameObject current;
    public GameObject next;

    public void OnClick()
    {
        current.SetActive(false);
        next.SetActive(true);
    }
}
