using UnityEngine;
using System.Collections;

public class PlayMultipleCreatureSounds : MonoBehaviour
{
    public AudioSource audioSource;      // Assign the existing Audio Source
    public AudioClip[] creatureClips;   // Array to hold multiple creature sounds

    public float minInterval = 5f;      // Minimum time between sounds
    public float maxInterval = 15f;     // Maximum time between sounds

    private void Start()
    {
        StartCoroutine(PlayOccasionalCreatureSounds());
    }

    private IEnumerator PlayOccasionalCreatureSounds()
    {
        // Wait for the initial sound to finish
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Loop to play occasional creature sounds
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            if (creatureClips.Length > 0)
            {
                // Pick a random clip from the array
                AudioClip randomClip = creatureClips[Random.Range(0, creatureClips.Length)];
                Debug.Log("Playing creature sound: " + randomClip.name);  // Debug log to confirm the sound
                audioSource.PlayOneShot(randomClip);
            }
        }
    }
}
