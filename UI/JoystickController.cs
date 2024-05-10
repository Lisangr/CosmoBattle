using UnityEngine;
using YG;

public class JoystickController : MonoBehaviour
{
    public GameObject mobileController;

    public static bool onMobile;
    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            onMobile = true;
            mobileController.SetActive(true);
        }
        else
        {
            onMobile = false;
            mobileController.SetActive(false);
        }
    }
}
