using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using YG;

public class StartSceneOnChangeLevelScene : MonoBehaviour
{ 
    public void StartScene()
    {
        TextMeshProUGUI buttonNameText = GetComponentInChildren<TextMeshProUGUI>();
        if (buttonNameText != null)
        {
            string buttonName = buttonNameText.text;
            int indexStartingScene;
            if (int.TryParse(buttonName, out indexStartingScene))
            {
                SceneManager.LoadScene(indexStartingScene);//+2
            }
            else
            {
                Debug.LogError("Can't translate text to number");
            }
        }
        else
        {
            Debug.LogError("TextMeshProUGUI not find on button");
        }
    }
}