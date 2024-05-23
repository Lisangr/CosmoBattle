using UnityEngine;
using UnityEngine.UI;
using YG;

public class VolumeSFX : MonoBehaviour
{
    [SerializeField] private Toggle m_SoundToggleSFX;
    [SerializeField] private AudioSource m_AudioSourceSFX;
    private float currentVolume = 1f;

    void Start()
    {
        currentVolume = PlayerPrefs.HasKey("VolumeSFX") ? PlayerPrefs.GetFloat("VolumeSFX") : 1f;
        m_AudioSourceSFX.volume = currentVolume;
    }

    void Update()
    {
        m_AudioSourceSFX.volume = currentVolume;

        if (m_SoundToggleSFX != null)
        {
            currentVolume = m_SoundToggleSFX.isOn ? currentVolume : 0f;
        }

        PlayerPrefs.SetFloat("VolumeSFX", currentVolume);
        PlayerPrefs.Save();
        Debug.Log("DATA VOLUMEsfx SAVE TO LOCAL");
        MySave();
        Debug.Log("DATA VOLUMEsfx SAVE TO CLOUD");
    }

    public void SetVolume(float volume) => currentVolume = volume;

    public void MySave()
    {
        YandexGame.savesData.volumeSFX = currentVolume;
        YandexGame.SaveProgress();
    }
}
