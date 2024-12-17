using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_script : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        //if (other.CompareTag("Player"))
        
            // Perform any pickup logic here (e.g., increase score, give item to player, etc.)
            Debug.Log("Item picked up!");

            // Destroy this game object
            Destroy(gameObject);
        
    }

     // Rotation speed in degrees per second
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    void Update()
    {
        // Rotate the object over time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
