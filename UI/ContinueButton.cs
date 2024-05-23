using System;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public Image pauseButton;
    public Sprite normalSprite;
    public GameObject pausePanel;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void OnClick()
    {
        Time.timeScale = 1.0f;
        pauseButton.sprite = normalSprite;
        animator.SetTrigger("Exit");
        pausePanel.SetActive(false);
    }
    public void ClickForAD()
    {
        gameObject.SetActive(false);
    }
}
