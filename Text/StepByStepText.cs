using System.Collections;
using UnityEngine;
using TMPro;

public class StepByStepText : MonoBehaviour
{
    public TextMeshProUGUI textGameObject;
    public float speedText = 0.05f;

    private string text;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        text = textGameObject.text;
        textGameObject.text = "";
        StartCoroutine(TextCorutine());
    }

    private IEnumerator TextCorutine()
    {
        foreach (char abc in text)
        {
            textGameObject.text += abc;
            yield return new WaitForSeconds(speedText);
        }
    }
}
