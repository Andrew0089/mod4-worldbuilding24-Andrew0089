using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the Audio Source for music
    public AudioSource initialSoundSource; // Reference to the Audio Source for initial sound

    void Start()
    {
        // Make sure the music doesn't start on awake
        musicSource.Pause(); // Pause it initially (if needed)

        // Play initial sound on awake
        initialSoundSource.Play();

        // Wait for the initial sound to finish before playing music
        Invoke("PlayMusic", initialSoundSource.clip.length);
    }

    void PlayMusic()
    {
        musicSource.Play(); // Play background music after initial sound finishes
    }
}
