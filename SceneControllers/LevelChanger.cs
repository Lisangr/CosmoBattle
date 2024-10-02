using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelChanger : MonoBehaviour
{
    private int levelUnLock;
    public Button[] buttons;
    private int levelUnLockFromYandexCloud;
    
    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveFromCloud;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveFromCloud;
    }

    void Start()
    {
        LoadSaveFromCloud();

        levelUnLock = PlayerPrefs.GetInt("levels", 1);

        if (levelUnLock >= levelUnLockFromYandexCloud)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }

            for (int i = 0; i < levelUnLock; i++)
            {
                buttons[i].interactable = true;
            }
        }
        if (levelUnLock <= levelUnLockFromYandexCloud)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }

            for (int i = 0; i < levelUnLockFromYandexCloud; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }
    public void LoadSaveFromCloud()
    {
        levelUnLockFromYandexCloud = YandexGame.savesData.levelPassed;
        Debug.Log("Загружен уровень" + levelUnLockFromYandexCloud);
    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
