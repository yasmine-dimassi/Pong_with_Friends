using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
    public class Gamemanager : MonoBehaviourPunCallbacks
{

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;

    public GameObject player1SpawnPosition;
    public GameObject player2SpawnPosition;
    public GameObject ballSpawnTransform;
    public GameObject RightWallSpawnPosition;
    public GameObject LeftWallSpawnPosition;

    private GameObject ball;
    private GameObject player1;
    private GameObject player2;
    private GameObject RightWall;
    private GameObject LeftWall;

    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected) // 1
            {
                SceneManager.LoadScene("Launcher");
                return;
            }

            if (PlayerManager.LocalPlayerInstance == null)
            {
                if (PhotonNetwork.IsMasterClient) // 2
                {
                    Debug.Log("Instantiating Player 1");
                    // 3
                    player1 = PhotonNetwork.Instantiate("pongPaddle1", player1SpawnPosition.transform.position, player1SpawnPosition.transform.rotation, 0);
                    // 4
                    ball = PhotonNetwork.Instantiate("Ball", ballSpawnTransform.transform.position, ballSpawnTransform.transform.rotation, 0);
                    Debug.Log("Instantiating a Ball");
                    ball.name = "Ball";
                    RightWall = PhotonNetwork.Instantiate("RightWall", RightWallSpawnPosition.transform.position, RightWallSpawnPosition.transform.rotation, 0);
                    LeftWall = PhotonNetwork.Instantiate("LeftWall", LeftWallSpawnPosition.transform.position, LeftWallSpawnPosition.transform.rotation, 0);
                    Debug.Log("Instantiating a LeftWall");
                }
                else // 5
                {
                   player2 = PhotonNetwork.Instantiate("pongPaddle2", player2SpawnPosition.transform.position, player2SpawnPosition.transform.rotation, 0);
                   Debug.Log("Instantiating Player 2");
                  
                }

            }
    }
    public static void Score (string wallID) {
    if (wallID == "RightWall")
    {
        PlayerScore1++;
    } else
    {
        PlayerScore2++;
    }
    }

    void OnGUI () {
    GUI.skin = layout;
    GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
    GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

    if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
      
    }

    if (PlayerScore1 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
        ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    } else if (PlayerScore2 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
        ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    }
      
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
}