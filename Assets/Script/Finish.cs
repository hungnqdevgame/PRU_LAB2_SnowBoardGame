using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishLine;
    [SerializeField] GameObject winUI;
    private bool isWin = false;

    public bool GetWin()
    {
       return isWin;
    }
    void Start()
    {
        winUI.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            finishLine.Play();
            isWin = true; // Set the win condition to true
                          // Pause the game
            StartCoroutine(WinGame());

        }
       
    }
   

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(loadDelay);
        winUI.SetActive(true);
         // Pause the game
    }
}
