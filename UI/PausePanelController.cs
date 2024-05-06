using UnityEngine;

public class PausePanelController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 || Input.GetKey(KeyCode.Escape))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ��� ��������� ��������� ����������� Input.GetTouch(0).position
            if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), clickPosition))
            {
                gameObject.SetActive(false);
            }
            Time.timeScale = 1.0f;
        }
    }
}