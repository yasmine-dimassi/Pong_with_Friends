using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool inPlay = false;
    public bool inPause = false;
    public bool gameOver = false;

    public static string theme;

    public int lifes_remaining_input;
    public int lifes_remaining;
    public Text lifes_remaining_text;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject mainMenuPanel;

    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        playPanel.SetActive(true);
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        lifes_remaining = lifes_remaining_input;
    }
    private void OnEnable()
    {
        instance = this;
    }

    private void Update()
    {

        //update lifes UI
        if (theme == "Retro Game" || theme  == "Chinese")
        {
            UpdateHearts();
        }
        else
        {
            UpdateLifesText();
        }

        //check if gameover
        GameOver();

        //first time
        if (inPlay == false && gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //update UI
                playPanel.SetActive(false);

                //start the game 
                inPlay = true;
            }
        }

        //after 
        if (inPlay == false && gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //update UI
                gameOverPanel.SetActive(false);
                playPanel.SetActive(false);

                lifes_remaining = lifes_remaining_input;
   
                //start the game 
                gameOver = false;
                //inPause = false; // this to unpause the ball 
                inPlay = true;
            }

        }

        //pause-unpause game
        if (Input.GetKeyDown(KeyCode.Escape) && inPlay == true)
        {
            PauseGameToggle();
        }


    }
    void GameOver()
    {
        if (!gameOver)
        {
            if (lifes_remaining == 0)
            {
                //end game
                gameOver = true;
                inPlay = false;

                //update UI
                gameOverPanel.SetActive(true);
                playPanel.SetActive(true);
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGameToggle()
    {
        //pause game
        if (inPause == false)
        {
            inPause = true;
            pausePanel.SetActive(true);
            mainMenuPanel.SetActive(true);
            print("the game is paused");
        }

        //unpause game
        else if (inPause == true)
        {
            inPause = false;
            pausePanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            print("the game is unpaused");
        }

    }
    void UpdateLifesText()
    {
        lifes_remaining_text.text = lifes_remaining.ToString();
        print("text changed");
    }

    void UpdateHearts()
    {
        if (lifes_remaining == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
        if (lifes_remaining == 2)
        {
            Heart1.SetActive(false);
        }
        if (lifes_remaining == 1)
        {
            Heart2.SetActive(false);
        }
        if (lifes_remaining == 0)
        {
            Heart3.SetActive(false);
        }
    }

}



