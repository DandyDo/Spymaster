using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using System.Collections.Generic;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] TMP_Text StartGameButtonText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject StartGameButton;
    [SerializeField] byte MaxPlayersPerRoom = 8;

    List<RoomInfo> rooms = new List<RoomInfo>();

    public static Launcher Instance; // Singleton

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Connecting to Master...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true; // switch everyone's scene to master's scene (when he/she switches)
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("main menu");
        //Debug.Log("Joined Lobby");

        PhotonNetwork.NickName = "Player " + Random.Range(1, 8).ToString("0"); // keep it for now (auto nickname generation)
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null); // set room name and max number of players in room
        MenuManager.Instance.OpenMenu("connecting");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();

        RefreshConnection();
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("main menu");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1); // The "Map" scene 
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("connecting");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = "Room: " + PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.SetActive(true); // Set active for  the master client of room only
            StartGameButtonText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/8";
        }
    }

    // When Host leave migrate the host to someone else
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorText.text = "Failed to create/join room. Error: " + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var ri in roomList)
        {
            if (ri.RemovedFromList)
                rooms.Remove(FindRoom(ri.Name));
            else if (FindRoom(ri.Name) == null)
                rooms.Add(ri);
        }

        foreach (Transform transform in roomListContent)
        {
            Destroy(transform.gameObject);
        }

        foreach (RoomInfo ri in rooms)
        {             
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(ri);
        }
    }

    RoomInfo FindRoom(string name)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].Name == name)
                return rooms[i];
        }

        return null;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);

        StartGameButtonText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/8";

        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 8)
            {
                StartGameButton.GetComponent<Button>().interactable = true;
                StartGameButtonText.text = "Start";
            }
            else
            {
                StartGameButton.GetComponent<Button>().interactable = false;
                StartGameButtonText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/8";
            }
        }
    }

    public void RefreshConnection()
    {
        if (!PhotonNetwork.IsConnected)
        {
            //Debug.Log("Connecting to Master...");
            MenuManager.Instance.OpenMenu("connecting");
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
