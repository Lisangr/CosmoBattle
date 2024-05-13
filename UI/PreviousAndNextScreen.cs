using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousAndNextScreen : MonoBehaviour
{
    public GameObject nextScreen;
    public GameObject currentScreen;

    public void GoToNextScreen()
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);
    }
}
