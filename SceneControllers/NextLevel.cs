using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class NextLevel : MonoBehaviour
{
    public string sceneName;
    private int currentLevel;
    public void LoadNextLevel()
    {
        UnLockLevel();
        SceneManager.LoadScene(sceneName);        
    }
    public void UnLockLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
            MySaves();
            PlayerPrefs.Save();
        }
    }
    public void MySaves()
    {
        YandexGame.savesData.levelPassed = currentLevel + 1;
        YandexGame.SaveProgress();
    }
}
