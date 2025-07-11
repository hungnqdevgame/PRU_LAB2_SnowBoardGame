using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] menuUI;
    [SerializeField] private GameObject[] pauseUI;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI[] scoreText;
    [SerializeField] private TextMeshProUGUI speedScoreText;
    private int time;
    [SerializeField]
    private int score;
    private float speed;
    SurfaceEffector2D surfaceEffector2D;
    Crash crash;
    Finish finish;
    bool isPause = false;


    public void ModifyScore(int s)
    {
        
        score += s;
    }

    public int GetScore() => score; 
    public void LoadLevel()
    {
        Time.timeScale = 1; // Ensure the game is running at normal speed
       
        SceneManager.LoadScene(0);
       
    }

    public void LoadMenu()
    {
        Time.timeScale = 1; // Ensure the game is running at normal speed
        SceneManager.LoadScene(1);
        //crash.SetHeath(3); // Reset health to 3
    }

    private void Start()
    {
        for(int i = 0; i < menuUI.Length; i++)
        {
            menuUI[i].SetActive(false);
        }

        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        crash = FindAnyObjectByType<Crash>();
        finish = FindAnyObjectByType<Finish>();
    }


    public void ShowMenu( )
    {
        Time.timeScale = 0; // Pause the game
        isPause = true;
        for (int i = 0; i < menuUI.Length; i++)
        {
          
            menuUI[i].SetActive(true);
        }
        for(int i = 0; i < pauseUI.Length; i++)
        {
           
            pauseUI[i].SetActive(false);
        }
    }

    public void HideMenu()
    {
        Time.timeScale = 1; // Resume the game
        isPause = false;
        for (int i = 0; i < menuUI.Length; i++)
        {
            menuUI[i].SetActive(false);
        }
        for(int i = 0; i < pauseUI.Length; i++)
        {
            pauseUI[i].SetActive(true);
        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Application is quitting");
    }

    void Update()
    {
        ShowText();
        ShowScore();
        ShowSpeed();
    }
    void ShowText()
    {
         time = (int)Time.timeSinceLevelLoad;
       
        timeText.text = "" + time;
    }
    void ShowScore()
    {
        if (finish.GetWin() == false && isPause == false)
        {
            ModifyScore(1);
        }
        else if(finish.GetWin() == true || isPause == true) // If the game is won, stop modifying score
        {
            ModifyScore(0); // Stop modifying score if the game is won
        }

            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].text = "Score: " + GetScore(); // Display score with 2 decimal places
            }
    }

    void ShowSpeed()
    {
        
        speedScoreText.text = "Speed: " + surfaceEffector2D.speed; // Display speed with 2 decimal places
    }

}
