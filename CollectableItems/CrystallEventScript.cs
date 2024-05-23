using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CrystallEventScript : MonoBehaviour
{
    public GameObject particleSystem;
    public delegate void DeathAction();
    public static event DeathAction OnCrystallDeath;

    public AudioClip[] audioClips; // Массив звуковых клипов
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        if (collision.CompareTag("Player"))
        {
            if (audioClips.Length > 0)
            {
                // Выбираем случайный звук из массива
                int randomIndex = Random.Range(0, audioClips.Length);
                AudioClip randomClip = audioClips[randomIndex];

                float currentVolume = PlayerPrefs.GetFloat("VolumeSFX", 1.0f); // Второй параметр - значение по умолчанию
                float currentVolumeYG = YandexGame.savesData.volume;

                if (currentVolumeYG != null)
                {
                    audioSource.volume = currentVolumeYG;
                    audioSource.clip = randomClip;
                    AudioSource.PlayClipAtPoint(randomClip, transform.position, currentVolumeYG);
                }
                else if (currentVolume != null)
                {
                    audioSource.volume = currentVolume;
                    audioSource.clip = randomClip;
                    AudioSource.PlayClipAtPoint(randomClip, transform.position, currentVolume);
                }
                else
                {
                    audioSource.volume = 1.0f;
                    audioSource.clip = randomClip;
                    AudioSource.PlayClipAtPoint(randomClip, transform.position);
                }

            }
            OnCrystallDeath?.Invoke();
            Destroy(gameObject);
            
        }
    }
}
