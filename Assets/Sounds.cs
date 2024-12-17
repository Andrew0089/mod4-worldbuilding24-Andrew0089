using UnityEngine;
using System.Collections;  // Needed for IEnumerator and coroutines

public class PlayOccasionalAmbientSounds : MonoBehaviour
{
    public AudioSource initialSoundSource;  // AudioSource for the initial sound
    public AudioSource ambientSoundSource;  // AudioSource for the first occasional ambient sound
    public AudioSource thirdAmbientSoundSource;  // AudioSource for the second occasional ambient sound

    public float ambientSoundDelay = 5f;    // Delay before the second ambient sound starts playing (in seconds)
    public float thirdSoundDelay = 10f;     // Delay before the third ambient sound starts playing (in seconds)
    public float thirdSoundDuration = 3f;   // Duration for which the third ambient sound will play (in seconds)

    private bool isThirdSoundPlaying = false;  // To track if the third sound is already playing

    void Start()
    {
        // Play the initial sound
        initialSoundSource.Play();

        // Start the coroutine to handle sound playback
        StartCoroutine(HandleAmbientSounds());
    }

    private IEnumerator HandleAmbientSounds()
    {
        // Wait until the initial sound is done
        yield return new WaitForSeconds(initialSoundSource.clip.length);

        // Play the first ambient sound occasionally (plays once and stops)
        ambientSoundSource.Play();

        // Wait for the specified delay before starting the third ambient sound
        yield return new WaitForSeconds(ambientSoundDelay);

        // After the first sound, start the third ambient sound after its delay
        StartCoroutine(PlayThirdAmbientSoundAfterDelay());
    }

    private IEnumerator PlayThirdAmbientSoundAfterDelay()
    {
        // Wait for the specified delay before starting the third ambient sound
        yield return new WaitForSeconds(thirdSoundDelay);

        // Check if the third sound is already playing to avoid overlapping
        if (!isThirdSoundPlaying)
        {
            // Play the third ambient sound (but only for a limited duration)
            thirdAmbientSoundSource.Play();

            // Mark that the third sound is now playing
            isThirdSoundPlaying = true;

            // Wait for the duration of the third sound before stopping it
            yield return new WaitForSeconds(thirdSoundDuration);

            // Stop the third sound after the specified duration
            thirdAmbientSoundSource.Stop();

            // Mark that the third sound has stopped playing
            isThirdSoundPlaying = false;
        }
    }
}
