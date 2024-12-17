using UnityEngine;
using System.Collections;

public class PlayOccasionalAmbientSounds : MonoBehaviour
{
    public AudioSource initialSoundSource;      // AudioSource for the initial sound
    public AudioSource ambientSoundSource;      // AudioSource for the first occasional ambient sound
    public AudioSource thirdAmbientSoundSource; // AudioSource for the second occasional ambient sound
    public AudioSource loopAmbientSoundSource;  // AudioSource for the continuous loop sound (background music)

    public float initialSoundDuration = 5f;     // Duration for how long the initial sound will play (in seconds)
    public float musicStartDelay = 2f;          // Delay after the initial sound before the music starts (in seconds)
    public float ambientSoundDelayMin = 5f;     // Minimum delay before the first ambient sound starts (in seconds)
    public float ambientSoundDelayMax = 10f;    // Maximum delay before the first ambient sound starts (in seconds)
    public float thirdSoundDelayMin = 8f;       // Minimum delay before the second ambient sound starts (in seconds)
    public float thirdSoundDelayMax = 12f;      // Maximum delay before the second ambient sound starts (in seconds)

    private bool isThirdSoundPlaying = false;   // To track if the third sound is already playing

    void Start()
    {
        // Play the initial sound first
        initialSoundSource.Play();

        // Start the coroutine to handle delayed playback
        StartCoroutine(HandleSoundsAfterInitial());
    }

    private IEnumerator HandleSoundsAfterInitial()
    {
        // Wait for the initial sound to finish (or play for a fixed duration if you want)
        yield return new WaitForSeconds(initialSoundDuration);  // If you want to play it for a set duration, use this

        // After the initial sound finishes, start playing the background music loop
        loopAmbientSoundSource.loop = true;  // Set the loop flag to true for continuous looping
        loopAmbientSoundSource.Play();  // Start playing the background music

        // Wait for a few seconds after the music starts before the ambient sounds begin (musicStartDelay)
        yield return new WaitForSeconds(musicStartDelay);

        // Start playing the first ambient sound after a random delay within the specified range
        float randomDelay = Random.Range(ambientSoundDelayMin, ambientSoundDelayMax);
        yield return new WaitForSeconds(randomDelay);
        ambientSoundSource.Play();  // Play the first ambient sound

        // Start the second ambient sound after a random delay within the specified range
        randomDelay = Random.Range(thirdSoundDelayMin, thirdSoundDelayMax);
        yield return new WaitForSeconds(randomDelay);
        StartCoroutine(PlayThirdAmbientSoundAfterDelay());
    }

    private IEnumerator PlayThirdAmbientSoundAfterDelay()
    {
        // Check if the third sound is already playing to avoid overlapping
        if (!isThirdSoundPlaying)
        {
            // Play the third ambient sound (but only for a limited duration)
            thirdAmbientSoundSource.Play();

            // Mark that the third sound is now playing
            isThirdSoundPlaying = true;

            // Wait for the duration of the third sound before stopping it
            yield return new WaitForSeconds(thirdAmbientSoundSource.clip.length);

            // Stop the third sound after the specified duration
            thirdAmbientSoundSource.Stop();

            // Mark that the third sound has stopped playing
            isThirdSoundPlaying = false;
        }
    }
}
