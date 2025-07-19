using UnityEngine;

public class CheckGround : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Find the PlayerController in the scene
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene. Please ensure it is present.");
        }
    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
