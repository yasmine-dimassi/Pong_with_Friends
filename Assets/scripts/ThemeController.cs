using UnityEngine;
using UnityEngine.SceneManagement;


public class ThemeController : MonoBehaviour
{
    public static ThemeController instance;

    string theme = "Retro Game";

    private void Update()
    {
        //continue
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameController.theme = theme;
            if (theme == "Futuristic")
            {
                SceneManager.LoadScene("FuturisticSoloGame");
            }
            else if (theme == "Chinese")
            {
                SceneManager.LoadScene("ChineseSoloGame");
            }
            else if (theme == "Tunisian")
            {
                SceneManager.LoadScene("TunisianSoloGame");
            }
            else
            {
                SceneManager.LoadScene("RetroGameSoloGame");
            }
        }

        //quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetFuturisticTheme()
    {
        theme = "Futuristic";
        Debug.Log("theme set to " + theme);
    }
    public void SetChineseTheme()
    {
        theme = "Chinese";
        Debug.Log("theme set to " + theme);
    }
    public void SetTunisianTheme()
    {
        theme = "Tunisian";
        Debug.Log("theme set to " + theme);
    }
    public void SetRetroGameTheme()
    {
        theme = "Retro Game";
        Debug.Log("theme set to " + theme);
    }

}
