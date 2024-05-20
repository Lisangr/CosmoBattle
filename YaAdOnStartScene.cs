using UnityEngine;
using YG;

public class YaAdOnStartScene : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void Start()
    {
        YandexGame.FullscreenShow();
    }
}
