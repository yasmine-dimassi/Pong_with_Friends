using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UsernameController : MonoBehaviour
{
    public InputField username;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pass the username to the main menu script (MenuNavigation)
            if (username.text != "")
            {
                MenuNavigation.usernameString = username.text;
            }
            else
            {
                MenuNavigation.usernameString = "Anonymous";
            }

            // load main menu scene
            SceneManager.LoadScene("MainMenu"); 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
