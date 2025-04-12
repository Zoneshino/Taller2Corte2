using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private AudioSource musicSource;
    private bool isMusicOn = true;

    private void Awake()
    {
        if (instance == null)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        musicSource = GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        musicSource.mute = !isMusicOn;
    }

    public bool IsMusicOn()
    {
        return isMusicOn;
    }
}
