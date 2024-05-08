using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LevelChanger : MonoBehaviour
{
    private int levelUnLock;
    public Button[] buttons;
    private int levelUnLockFromYandexCloud;
    /*
    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveFromCloud;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveFromCloud;
    }*/

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
    /*
    for (int i = 0; i < buttons.Length; i++)
    {
        if (i < levelUnLock)
            buttons[i].interactable = true;
        else
            buttons[i].interactable = false;
    }
        for (int i = 1; i < levelUnLock; i++)
        {
            //int buttonIndex = i;//Mathf.Clamp(i - 1, 0, buttons.Length - 1);

            if (PlayerPrefs.HasKey("stars" + i))
            {
                if (PlayerPrefs.GetInt("stars" + i) == 1)
                {
                buttons[i - 1].transform.GetChild(0).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = star;
                buttons[i - 1].transform.GetChild(1).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = noStar;
                buttons[i - 1].transform.GetChild(2).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("stars" + i) == 2)
                {
                buttons[i - 1].transform.GetChild(0).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = star;
                buttons[i - 1].transform.GetChild(1).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = star;
                buttons[i - 1].transform.GetChild(2).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("stars" + i) == 3)
                {
                buttons[i - 1].transform.GetChild(0).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(0).GetComponent<Image>().sprite = star;
                buttons[i - 1].transform.GetChild(1).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = star;
                buttons[i - 1].transform.GetChild(2).gameObject.SetActive(true);
                buttons[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = star;
                }
            }
            else
            {
            buttons[i - 1].transform.GetChild(0).gameObject.SetActive(true);
            buttons[i - 1].transform.GetChild(0).gameObject.SetActive(false);
            buttons[i - 1].transform.GetChild(1).gameObject.SetActive(true);
            buttons[i - 1].transform.GetChild(1).gameObject.SetActive(false);
            buttons[i - 1].transform.GetChild(2).gameObject.SetActive(true);
            buttons[i - 1].transform.GetChild(2).gameObject.SetActive(false);
            }
        }

}
    */
    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
