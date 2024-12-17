using TMPro;  // For TextMeshPro
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timeLimit = 180f; // Set the time limit to 3 minutes (180 seconds)
    private float timeRemaining;

    public int totalParts = 10; // Total number of parts to collect
    private int partsCollected = 0; // Number of parts collected

    public TMP_Text timerText; // For TextMeshPro timer text
    public TMP_Text gameOverMessageText; // For TextMeshPro Game Over message text
    public GameObject gameOverUI; // UI Panel to show when the game is over

    private bool gameOver = false;

    void Start()
    {
        timeRemaining = timeLimit;
        gameOverUI.SetActive(false); // Hide Game Over UI initially
        gameOverMessageText.gameObject.SetActive(false); // Hide the Game Over message text initially
    }

    void Update()
    {
        if (gameOver)
            return; // Don't update anything if the game is over

        // Update the timer
        timeRemaining -= Time.deltaTime;

        // Update the UI text
        timerText.text = "Time Remaining: " + Mathf.Ceil(timeRemaining).ToString() + "s";

        // Check if the time is up
        if (timeRemaining <= 0 && !gameOver)
        {
            EndGame("Kabloom! You failed to collect all parts.");  // Display "Kabloom" message when time runs out
        }

        // Check if all parts are collected
        if (partsCollected >= totalParts && !gameOver)
        {
            EndGame("You Survived! All tools collected in time.");
        }
    }

    // Call this method when a part is collected
    public void CollectPart()
    {
        if (!gameOver)
        {
            partsCollected++;
            Debug.Log("Parts Collected: " + partsCollected);
        }
    }

    // Ends the game and shows the result message
    public void EndGame(string message)
    {
        gameOver = true;

        // Show the Game Over UI and message
        gameOverUI.SetActive(true);
        gameOverMessageText.gameObject.SetActive(true);
        gameOverMessageText.text = message;  // Set the "Kabloom" message or any other message
    }

    // Restarts the game (resetting the timer, parts, and other game-related elements)
    public void RestartGame()
    {
        // Reset the timer and parts collected
        timeRemaining = timeLimit;
        partsCollected = 0;

        // Hide the Game Over UI and message
        gameOverUI.SetActive(false);
        gameOverMessageText.gameObject.SetActive(false);

        // Reset other game-related elements (e.g., player position, etc.)
        // Example: player.transform.position = initialPosition;

        // Resume the game logic
        gameOver = false;
    }
}
