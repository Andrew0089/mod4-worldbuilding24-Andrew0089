using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    // Static count of tools collected (shared among all instances)
    public static int toolsCollected = 0;

    // Total tools in the game (set this in the inspector or manually)
    public int totalTools = 10;

    // Reference to the UI TextMeshPro Text
    public TextMeshProUGUI toolsCollectedText;

    private void Start()
    {
        // Ensure the toolsCollectedText UI is found and assigned
        if (toolsCollectedText == null)
        {
            toolsCollectedText = GameObject.Find("ToolsCollectedText").GetComponent<TextMeshProUGUI>();
        }

        // Make sure the UI starts with the correct number of tools
        UpdateUIText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Increase tools collected count
            toolsCollected++;

            // Update the UI Text
            UpdateUIText();

            // Optional: Perform pickup logic (e.g., play sound, spawn effect, etc.)
            Debug.Log("Item picked up!");

            // Destroy this game object (pick up the item)
            Destroy(gameObject);
        }
    }

    // Function to update the UI with the number of tools collected
    void UpdateUIText()
    {
        toolsCollectedText.text = "Tools Collected: " + toolsCollected + "/" + totalTools;

        // Check if all tools are collected and trigger game over or success logic
        if (toolsCollected >= totalTools)
        {
            // Trigger success logic (example: end game, display message, etc.)
            Debug.Log("All tools collected!");
            // You can call a function here to handle game end or something like a success message
        }
    }

    // Optional: Rotation speed in degrees per second for the pickups
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    void Update()
    {
        // Rotate the pickup object over time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
