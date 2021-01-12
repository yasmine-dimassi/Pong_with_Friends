using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Photon.Pun.Demo.PunBasics
{
public class Randommanager : MonoBehaviourPunCallbacks
{    
    [SerializeField]
        private GameObject controlPanel;

        [SerializeField]
        

        

        bool isConnecting;

        string gameVersion = "1";

        public GameObject player1SpawnPosition;
        public GameObject player2SpawnPosition;
        public GameObject ballSpawnTransform;

        private GameObject ball;
        private GameObject player1;
        private GameObject player2;
        
   
    [SerializeField]
    private LoadBalancingClient loadBalancingClient;

    // Start is called before the first frame update
    void Start()
    {
         ConnectToPhoton();
         if (PhotonNetwork.IsConnected) // 1
            {
                PhotonNetwork.JoinRandomRoom();
            }
    
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConnectToPhoton()
        {
            
            PhotonNetwork.GameVersion = gameVersion; //1
            PhotonNetwork.ConnectUsingSettings(); //2
        }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomOptions = roomOptions;
        loadBalancingClient.OpCreateRoom(enterRoomParams);
    }


    void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void OnJoinedRoom()
    {
        Debug.Log("Roomisjoined..");
        
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
                }
                else // 5
                {
                   player2 = PhotonNetwork.Instantiate("pongPaddle2", player2SpawnPosition.transform.position, player2SpawnPosition.transform.rotation, 0);
                   Debug.Log("Instantiating Player 2");
                }

            }
        

    }
    }
}


    // [..] Other callbacks implementations are stripped out for brevity, they are empty in this case as not used.

   


