using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class NextLevel : MonoBehaviour
{
    private int currentLevel;
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        UnLockLevel();

        SceneManager.LoadScene(nextSceneIndex);        
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
        Debug.Log("Уровень сохранен, следующий уровень" + currentLevel);
    }
}
