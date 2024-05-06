using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Start : MonoBehaviour
{
    public string Scene = "";

    public void onClickStart()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);

    }
}
