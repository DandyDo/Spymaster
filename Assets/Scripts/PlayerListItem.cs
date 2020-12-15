using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text text;
    Player player;

    public void SetUp (Player player)
    {
        this.player = player;

        text.text = this.player.NickName;

        if (player.NickName == PhotonNetwork.LocalPlayer.NickName)
        {
            text.text = "<b>" + text.text + "</b>";
        }
    }

    public override void OnPlayerLeftRoom (Player otherPlayer)
    {
        if (player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
