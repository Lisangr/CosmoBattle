using UnityEngine;
using YG;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();    
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (!PauseActivator.isPaused)
        {
            transform.Translate(Vector2.left * speed);             
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (audioClips.Length > 0)
            {
                int randomIndex = Random.Range(0, audioClips.Length);
                AudioClip randomClip = audioClips[randomIndex];

                float currentVolume = PlayerPrefs.GetFloat("VolumeSFX", 1.0f);
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
            collision.GetComponent<Player>().health -= damage;
            Destroy(gameObject);            
        }
    }
}
