using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
    public class GameLauncher : MonoBehaviourPunCallbacks
    {
      

        [SerializeField]
        private GameObject controlPanel;

        [SerializeField]
        private Text feedbackText;

        [SerializeField]
        private byte maxPlayersPerRoom = 2;

        bool isConnecting;

        string gameVersion = "1";

        [Space(10)]
        [Header("Custom Variables")]
        public InputField playerNameField;
        public InputField roomNameField;

        [Space(5)]
        public Text playerStatus;
        public Text connectionStatus;

        [Space(5)]
        public GameObject roomJoinUI;
        public GameObject buttonLoadArena;
        public GameObject buttonJoinRoom;

        string playerName = "";
        string roomName = "";

        void Start()
        {
      
            PlayerPrefs.DeleteAll();
            Debug.Log("Connecting to Photon Network");

            //update UI 
            roomJoinUI.SetActive(false);
            buttonLoadArena.SetActive(false);

            ConnectToPhoton();
        }

        private void Update()
        {
            playerName = playerNameField.text;
            roomName = roomNameField.text;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Return();
            }
        }

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        
        void destroy(){
            Debug.Log("DisConnecting from Destroy");
            PhotonNetwork.Disconnect();
            }
            

        public void SetPlayerName(string name)
        {
            playerName = name;
        }

        public void SetRoomName(string name)
        {
            roomName = name;
        }
       
        void ConnectToPhoton()
        {
            connectionStatus.text = "Loading...";
            PhotonNetwork.GameVersion = gameVersion; 
            PhotonNetwork.ConnectUsingSettings();
        }

        public void JoinRoom()
        {
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                Debug.Log("PhotonNetwork.IsConnected! | Trying to Create/Join Room " + roomNameField.text);
                Debug.Log("player name is : " + playerName);

                RoomOptions roomOptions = new RoomOptions(); //2

                TypedLobby typedLobby = new TypedLobby(roomName, LobbyType.Default); //3

                PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby); //4
                Debug.Log(roomNameField.text+" Room Created ");

            }
        }

        public void LoadArena()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
            {
                PhotonNetwork.LoadLevel("MultiplayerGame");
            }
            else
            {
                playerStatus.text = "An other player is needed!";
                playerStatus.color = Color.red;
            }
        }
        public void Return()
        {   Debug.Log("DisConnecting from Return");
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("PlayWithFriends", LoadSceneMode.Single);
        }

        public void MainMenu()
        {   Debug.Log("DisConnecting from MainMenu");
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        // Photon overriden Methods

        public override void OnConnected()
        {
            base.OnConnected();
            connectionStatus.text = "";

            Debug.LogError("Connected to Photon!");

            roomJoinUI.SetActive(true);
            buttonLoadArena.SetActive(false);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            isConnecting = false;
            controlPanel.SetActive(true);
            Debug.LogError("Disconnected. Please check your Internet connection.");
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("room joined by master client");
                buttonLoadArena.SetActive(true);
                buttonJoinRoom.SetActive(false);

                playerStatus.text = "Room Joined";
                playerStatus.text = "waiting for an opponent...";
            }
            else
            {
                playerStatus.text = "Room Joined";
                playerStatus.text = "Waiting for the room owner to start the game...";
            }
        }
    }
}

