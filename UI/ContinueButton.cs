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
        animator.SetTrigger("Exit");
        pausePanel.SetActive(false);
        pauseButton.sprite = normalSprite;
        Time.timeScale = 1.0f;
    }
}
