using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool inPlay = false;
    public bool inPause = false;
    bool gameOver = false;

    public int lifes_remaining;

    public Text lifes_remaining_text;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject mainMenuPanel;


    private void Start()
    {
        gameOverPanel.SetActive(false);
        playPanel.SetActive(true);
        pausePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    private void OnEnable()
    {
        instance = this;
    }

    private void Update()
    {
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
                lifes_remaining = 3;
                lifes_remaining_text.text = "3";

                //start the game 
                gameOver = false;
                inPlay = true;
            }

        }

        //pause-unpause game
        if (Input.GetKeyDown(KeyCode.Escape) && inPlay == true)
        {
            PauseGameToggle();
        }

        //check if gameover
        GameOver();
    }
    void GameOver()
    {
        if (!gameOver)
        {
            if (lifes_remaining <= 0)
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
        SceneManager.LoadScene(1);
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

}

