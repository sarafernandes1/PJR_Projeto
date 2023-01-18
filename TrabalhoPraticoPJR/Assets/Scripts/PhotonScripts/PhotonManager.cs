using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonManager : MonoBehaviourPunCallbacks
{
	public static PhotonManager Instance;

	public TMP_InputField roomNameinputField; // Nome da sala
	[SerializeField] Transform roomListContent; // Transform para colocar o nome das salas
	public GameObject roomListItemPrefab; 
	public GameObject playerListItemPrefab; 
	public Transform playerListContent; //Transform para colocar o nome dos jogadores
	public GameObject startGameButton; // Botão para começar jogo
	public static Player p1, p2;

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
	}

	// Cria a sala
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
		MenuManager.Instance.OpenMenu("salajogo"); //O menu da sala com o nome dos jogadores e botões para sair e jogar é apresentado
		roomNameinputField.text = PhotonNetwork.CurrentRoom.Name;

		Player[] players = PhotonNetwork.PlayerList;

		foreach (Transform child in playerListContent)
		{
			Destroy(child.gameObject);
		}


		for (int i = 0; i < players.Length; i++)
		{
			if(players[i].NickName=="") players[i].NickName= "Player " + Random.Range(0, 10000).ToString("0000");
			// Permite listar na tela o nome de todos os jogadores na sala
			Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
		}


		//if(players.Length>0 )p1 = players[0];
		//if(players.Length>1)p2 = players[1];
		//Quem for o dono da sala tem o botão de jogar ativo
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
			//Se uma sala for removida, se não tiver jogadores, a sala não é apresentada
			if (roomList[i].RemovedFromList)
				continue;

			// Permite listar na tela o nome das salas
			Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
		}
	}

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
	}

	//Se o master sair da sala, passa a ser outro o dono e a ter o botão de jogar
	public override void OnMasterClientSwitched(Player newMasterClient)
	{
		startGameButton.SetActive(PhotonNetwork.IsMasterClient);
	}

	public void ExitGame()
    {
		PhotonNetwork.LeaveLobby();
		Application.Quit();
    }

	public void StartGame()
	{
		PhotonNetwork.LoadLevel(1);
	}
}
