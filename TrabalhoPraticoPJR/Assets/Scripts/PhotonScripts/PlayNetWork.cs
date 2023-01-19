using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayNetWork : MonoBehaviour
{
    public MonoBehaviour[] scriptsIgnore;
    private PhotonView photonView;
    public GameObject[] camera;
    public Canvas playerCanvas;
    public Text nickname;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var script in scriptsIgnore)
            {
                script.enabled = false;
               
            }

            foreach(GameObject obj in camera)
            {
                obj.SetActive(false);
            }

            playerCanvas.enabled = false;
        }
        else
        {
            int i = PhotonNetwork.LocalPlayer.ActorNumber;
            nickname.text = PhotonNetwork.PlayerList[i - 1].NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
