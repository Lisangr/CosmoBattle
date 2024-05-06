using UnityEngine;

public class SettingsActivator : MonoBehaviour
{
    public GameObject panel;
    private void Awake() => panel.SetActive(false);
    public void OnClick()
    { 
        panel.SetActive(true);
    }
}
