using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class JogoMenu : MonoBehaviourPunCallbacks
{
	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LoadLevel(0);
	}

}
