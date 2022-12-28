using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
	public static PhotonManager Instance;

	public TMP_InputField roomNameinputField;
	public Text roomName;
	[SerializeField] Transform roomListContent;
	public GameObject roomListItemPrefab;
	public GameObject playerListItemPrefab;
	public Transform playerListContent;
	public GameObject startGameButton;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		Debug.Log("Connecting to Master");
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		Debug.Log("Connected to Master");
		PhotonNetwork.JoinLobby();
		PhotonNetwork.AutomaticallySyncScene = true;
	}

	public override void OnJoinedLobby()
	{
		MenuManager.Instance.OpenMenu("menuinicial");
		Debug.Log("Joined Lobby");
		PhotonNetwork.NickName = "Player" + Random.Range(1, 10).ToString();
	}

	public void CreateRoom()
	{
		if (string.IsNullOrEmpty(roomNameinputField.text))
		{
			return;
		}
		PhotonNetwork.CreateRoom(roomNameinputField.text);
		MenuManager.Instance.OpenMenu("loading");
	}

	public override void OnJoinedRoom()
	{
		MenuManager.Instance.OpenMenu("salajogo");
		roomNameinputField.text = PhotonNetwork.CurrentRoom.Name;


		Player[] players = PhotonNetwork.PlayerList;

		for (int i = 0; i < players.Length; i++)
		{
			Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
		}

		//PhotonNetwork.Instantiate("Player", new Vector2(Random.Range(-5, 7), 3.0f), Quaternion.identity);
		//PhotonNetwork.Instantiate("Inimigo", new Vector2(Random.Range(-8, 2), 3.0f), Quaternion.identity);
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
		MenuManager.Instance.OpenMenu("loading");
	}

	public override void OnLeftRoom()
	{
		MenuManager.Instance.OpenMenu("title");
	}

	public void JoinRoom(RoomInfo info)
	{
		PhotonNetwork.JoinRoom(info.Name);
		MenuManager.Instance.OpenMenu("loading");
	}

	public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
		foreach (Transform trans in roomListContent)
		{
			Destroy(trans.gameObject);
		}

		for (int i = 0; i < roomList.Count; i++)
		{
			if (roomList[i].RemovedFromList)
				continue;
			Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
		}
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
	}

	public override void OnMasterClientSwitched(Player newMasterClient)
	{
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

	public void StartGame()
	{
		PhotonNetwork.LoadLevel(1);
	}
}
