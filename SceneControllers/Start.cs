using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string Scene = "";

    public void onClickStart()
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
}
