using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text numOfPlayers;
    public RoomInfo info;

    public void SetUp(RoomInfo info)
    {
        this.info = info;
        roomName.text = info.Name;
        numOfPlayers.text = info.PlayerCount + "/8";
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
