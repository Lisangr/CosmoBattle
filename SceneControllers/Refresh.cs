using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Refresh : MonoBehaviour
{
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
