using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject[] hearts;
    [SerializeField] int health = 3;

    private Vector3 lastTriggerPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            health--; // Decrease health by 1
            UpdateHearts();
            Debug.Log("Player hit the ground! Health: " + health);

            if (health > 0)
            {
                // Store the position where the player hit the ground
                lastTriggerPosition = transform.position;

                // Optionally, you can offset the respawn position to avoid immediate retrigger
                Vector3 respawnPosition = lastTriggerPosition + Vector3.up * 4f;
                transform.position = respawnPosition;
                transform.rotation = Quaternion.identity; // Reset rotation


                // Optionally, reset velocity if using Rigidbody2D
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
            }
            else
            {
                ShowGameOver();
            }
        }
    }

    private void Start()
    {
        UpdateHearts();
        gameOverUI.SetActive(false);
    }

    void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < health);
        }
    }

    public void ResetHealth()
    {
        health = 3;
        UpdateHearts();
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        // Optionally, move player to a start position here
        SceneManager.LoadScene(0);
    }
}