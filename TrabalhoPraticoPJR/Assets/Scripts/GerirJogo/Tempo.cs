using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Tempo : MonoBehaviour
{
    //bool startTimer = false;
    //public double timerIncrementValue;
    //double startTime;
    //[SerializeField] double timer = 100;
    //ExitGames.Client.Photon.Hashtable CustomeValue;
    //public GameObject[] players;

    //void Start()
    //{
    //    players = new GameObject[3];
    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        CustomeValue = new ExitGames.Client.Photon.Hashtable();
    //        startTime = PhotonNetwork.Time;
    //        startTimer = true;
    //        CustomeValue.Add("StartTime", startTime);
    //        PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
    //    }
    //    else
    //    {
    //        startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
    //        startTimer = true;
    //    }
    //}

    //void Update()
    //{
    //    players = GameObject.FindGameObjectsWithTag("Player");
    //    if (!startTimer) return;
    //    timerIncrementValue = PhotonNetwork.Time - startTime;
    //    if (timerIncrementValue >= timer)
    //    {
          

    //    }

    //}
}
