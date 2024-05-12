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
        pauseButton.rectTransform.localScale = new Vector3(1.18f, 1.0f, 1.0f);
        pauseButton.rectTransform.localScale = Vector3.one;
        pauseButton.sprite = normalSprite;
        animator.SetTrigger("Exit");
        pausePanel.SetActive(false);      
        
    }
}
