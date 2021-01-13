using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }
    public void StartPrivateMatch()
    {
        SceneManager.LoadScene("PrivateRoom", LoadSceneMode.Single);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
    public void StartRandomMatch()
    {
        SceneManager.LoadScene("RandomMatch", LoadSceneMode.Single);
    }
}
