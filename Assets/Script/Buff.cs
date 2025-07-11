using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

public class Buff : MonoBehaviour
{
    SurfaceEffector2D surfaceEffector2D;
    PlayerController playerController;
    LevelManager levelManager;

    private void Start()
    {
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        if(surfaceEffector2D == null)
        {
            Debug.Log("SurfaceEffector2D not found in the scene. Please ensure it is present.");
            return;
        }
        playerController = FindAnyObjectByType<PlayerController>();
        levelManager = FindAnyObjectByType<LevelManager>();
        if(levelManager == null)
        {
            Debug.Log("LevelManager not found in the scene. Please ensure it is present.");
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           StartCoroutine(BuffCour()); // Start the coroutine to apply the buff effect
            Debug.Log("Buff");
            levelManager.ModifyScore(100); // Increase the score by 10 when the buff is collected
            GetComponent<SpriteRenderer>().enabled = false; // Hide the buff visually
            GetComponent<Collider2D>().enabled = false; // Prevent multiple triggers
        }
       // Destroy the buff object after applying the effect
    }


    IEnumerator BuffCour()
    {
        BuffSpeed(); // Call the method to increase speed
        yield return new WaitForSeconds(1f); // Wait for 5 seconds
        NormalSpeed(); // Call the method to reset speed
        Debug.Log("Buff effect applied for 5 seconds.");
        Destroy(gameObject); // Destroy the buff object after applying the effect
    }
   
    void BuffSpeed()
    {
        surfaceEffector2D.speed = 50f; // Increase the speed by 5 units
    }
    void NormalSpeed()
    {
        surfaceEffector2D.speed = 25f; // Reset the speed to normal
    }
  
}

