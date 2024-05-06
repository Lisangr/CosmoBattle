using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle m_SoundToggle;
    [SerializeField] private AudioSource m_AudioSource;
    private float m_Volume = 1f;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        m_Volume = PlayerPrefs.HasKey("Volume") ? PlayerPrefs.GetFloat("Volume") : 1f;
        m_AudioSource.volume = m_Volume;
    }

    void Update()
    {
        m_AudioSource.volume = m_Volume;

        if (m_SoundToggle != null)
        {
            m_Volume = m_SoundToggle.isOn ? m_Volume : 0f;
        }
        
        PlayerPrefs.SetFloat("Volume", m_Volume);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume) => m_Volume = volume;
}
