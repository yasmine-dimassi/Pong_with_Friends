using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public static MenuNavigation instance;
    //to get the username from the previous scene 
    public static string usernameString = "Anonymous";
    public Text username;

    private void Update()
    {
        //return 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Username");
        }
    }

    public void Start()
    {
        username.text = usernameString;
    }
    public void PlayAlone()
    {
        SceneManager.LoadScene("Theme");
    }
    /*public void PlayWithFriends()
    {
        SceneManager.LoadScene();
    }*/
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
