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
            EndGame("Kabloom! You failed to collect all parts.");
        }
    }

    // Call this method when a part is collected
    public void CollectPart()
    {
        if (gameOver)
            return; // Do nothing if the game is already over

        partsCollected++;
        Debug.Log($"Parts Collected: {partsCollected}/{totalParts}");

        // Check if all parts are collected
        if (partsCollected >= totalParts)
        {
            EndGame("You Survived! All tools collected in time.");
        }
    }

    // Ends the game and shows the result message
    public void EndGame(string message)
    {
        gameOver = true;

        // Show the Game Over UI and message
        gameOverUI.SetActive(true);
        gameOverMessageText.gameObject.SetActive(true);
        gameOverMessageText.text = message;
        Debug.Log("Game Over: " + message);
    }
}
