using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		// Check if owned by local player
		if (PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{
		PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
	}
}