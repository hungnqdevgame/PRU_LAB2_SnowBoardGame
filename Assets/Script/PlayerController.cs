using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 50;
    [SerializeField] float baseSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] bool isJump ; // Variable to track if the player has jumped  
    [SerializeField] AudioSource soundEffect;

    public void SetJump()
    {
          isJump = true;
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
       
    }


    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        Jump();
    }

    void RespondToBoost()
    {
        //surfaceEffector2D.speed = 20f; // Reset to base speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = 50f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = 10f;
        }
       
        
      
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   

            
                rb2d.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                soundEffect.mute = true; // Unmute sound effect


        }
               
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
          isJump = true; // Allow jumping again when touching the ground
        }
        
    }

}
