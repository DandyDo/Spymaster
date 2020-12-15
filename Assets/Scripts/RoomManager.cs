using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
	public static RoomManager Instance; // Singleton

	void Awake()
	{
		// Check if there is a running instance
		if (Instance)
		{
			Destroy(gameObject);
			return;
		}

		// Keep only this instance running
		DontDestroyOnLoad(gameObject);
		Instance = this;
	}

	public override void OnEnable()
	{
		base.OnEnable();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public override void OnDisable()
	{
		base.OnDisable();
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (scene.buildIndex == 1) // The Map Scene at index 1
		{
			PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity); // PhotonPrefabs is found in the Resources folder
		}
	}
}
