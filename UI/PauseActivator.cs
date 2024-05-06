using UnityEngine;
using UnityEngine.UI;

public class PauseActivator : MonoBehaviour
{
    public Image buttonImage; 
    public Sprite normalSprite; 
    public Sprite pressedSprite; 
    public GameObject panel;
    private static bool isPaused = false; // ����, �����������, ��������� �� ���� � ��������� �����

    private void Awake()
    {
        buttonImage.sprite = normalSprite;
        panel.SetActive(false);
    }

    public void OnClick()
    {// ��������� ��������� ����
        if (!isPaused)
        {
            buttonImage.sprite = pressedSprite;
            panel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true; // ���� � ��������� �����
        }
        else
        {
            buttonImage.sprite = normalSprite;
            panel.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false; // ����c ����� �� ��������� �����
        }
    }
}