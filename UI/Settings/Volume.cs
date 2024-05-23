using UnityEngine;
using UnityEngine.UI;
using YG;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle m_SoundToggle;
    [SerializeField] private AudioSource m_AudioSource;
    private float currentVolume = 1f;

    void Start()
    {        
        currentVolume = PlayerPrefs.HasKey("Volume") ? PlayerPrefs.GetFloat("Volume") : 0.1f;
        m_AudioSource.volume = currentVolume;
    }

    void Update()
    {
        m_AudioSource.volume = currentVolume;

        if (m_SoundToggle != null)
        {
            currentVolume = m_SoundToggle.isOn ? currentVolume : 0f;
        }


        PlayerPrefs.SetFloat("Volume", currentVolume);
        PlayerPrefs.Save();
        Debug.Log("DATA VOLUME SAVE TO LOCAL");
        MySave();
        Debug.Log("DATA VOLUME SAVE TO CLOUD");
    }

    public void SetVolume(float volume) => currentVolume = volume;

    public void MySave()
    {
        YandexGame.savesData.volume = currentVolume; 
        YandexGame.SaveProgress();
    }
}