using UnityEngine;
using System.Collections;
using TMPro;

public class IntroMessageScript : MonoBehaviour
{
    // Reference to the TextMeshPro text component
    public TextMeshProUGUI messageText;

    // Duration in seconds to show the message
    public float messageDuration = 8f;

    void Start()
    {
        // Ensure the message is visible when the game starts
        messageText.gameObject.SetActive(true);

        // Start the coroutine to hide the message after the specified duration
        StartCoroutine(HideMessageAfterDelay());
    }

    IEnumerator HideMessageAfterDelay()
    {
        // Wait for the specified message duration
        yield return new WaitForSeconds(messageDuration);

        // Hide the message
        messageText.gameObject.SetActive(false);
    }
}
