using UnityEngine;
using YG;

public class RandomSoundOnLoad : MonoBehaviour
{
    public AudioClip[] audioClips; 
    private AudioSource audioSource;
    /*private void Awake()
    {
        Time.timeScale = 1.0f;
    }*/
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float currentVolume = PlayerPrefs.GetFloat("Volume", 0.1f); 
        float currentVolumeYG = YandexGame.savesData.volume;

        if (currentVolumeYG != null)
        {
            audioSource.volume = currentVolumeYG;
        }
        else if (currentVolume != null)
        {
            audioSource.volume = currentVolume;
        }
        else
        {
            audioSource.volume = 0.1f;
        }

        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];

            audioSource.clip = randomClip;
            audioSource.Play();
        }
    }
}