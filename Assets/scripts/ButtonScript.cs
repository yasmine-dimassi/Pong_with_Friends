using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void StartGame ( string levelName){SceneManager.LoadScene("Launcher", LoadSceneMode.Single);}
    public void ReturnToMainMenu ( string levelName){SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);}
    
    public void startRandomMatch ( string levelName){SceneManager.LoadScene("RandomMatch", LoadSceneMode.Single);}
}
