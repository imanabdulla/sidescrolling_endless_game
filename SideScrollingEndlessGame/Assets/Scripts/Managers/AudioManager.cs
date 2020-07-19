using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Clips
    {
        public AudioClip lose;
        public AudioClip tap;
    }
    public Clips clips;

    private AudioSource  audioSource;

    #region  singleton
    public static AudioManager audioManager;
    private void Awake()
    {
        if (audioManager == null)
            audioManager = this;
    }
    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
}