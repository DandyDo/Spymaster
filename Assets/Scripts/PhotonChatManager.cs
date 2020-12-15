using UnityEngine;
using TMPro;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    [SerializeField] GameObject chatPanel;
    [SerializeField] TMP_InputField inputFieldText;
    [SerializeField] TMP_Text chatText;
    [SerializeField] TMP_Text PlayerNameText;
    // [SerializeField] private string blueTeam = "blue";
    // [SerializeField] private string redTeam = "red";

    private string nickName;
    private ChatClient chatClient;
    public static PhotonChatManager Instance; // Singleton

    void Awake()
    {
        nickName = PhotonNetwork.NickName;
    }

    // Start is called before the first frame update
    void Start()
    {
        chatClient = new ChatClient(this);
        ConnectToPhotonChat();
    }

    // Update is called once per frame
    void Update()
    {
        chatClient.Service();
    }

    public void ConnectToPhotonChat()
    {
        //Debug.Log("Connecting to Chat...");
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(nickName));
    }

    public void OnDisconnected()
    {
        
    }

    public void OnConnected()
    {
        //Debug.Log("Connected to Chat. As " + PhotonNetwork.NickName);
        PlayerNameText.text = PhotonNetwork.NickName;
        chatClient.Subscribe(new string[] { "blue" }); // subscribe to chat channel once connected to server
    }

    public void OnChatStateChange(ChatState state)
    {
        
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        int msgCount = messages.Length;
        string msg; 
        //go through each received msg
        for (int i = 0; i < msgCount; i++)
        {
            msg = (string)messages[i];

            chatText.text += msg + "\n";
        }
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("Subscribed to a new channel!");
    }

    public void PublishMessage ()
    {
        if (string.IsNullOrEmpty(inputFieldText.text))
        {
            return;
        }

        chatClient.PublishMessage("blue", PhotonNetwork.NickName + ": " + inputFieldText.text);
        inputFieldText.text = "";
    }

    public void OnUnsubscribed(string[] channels)
    {
        
    }

    public void OnUserSubscribed(string channel, string user)
    {
        
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        
    }

    public void displayChat ()
    {
        if (chatPanel.activeSelf)
        {
            chatPanel.SetActive(false);
        }
        else
        {
            chatPanel.SetActive(true);
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////
    
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }
    public void DebugReturn(DebugLevel level, string message)
    {

    }
}
