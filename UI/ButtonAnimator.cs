using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMouseEnter()
    {
        animator.SetTrigger("Hover");
    }

    public void OnMouseExit()
    {
        animator.SetTrigger("Exit");
    }
}
