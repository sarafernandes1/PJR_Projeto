using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GerirJogo : MonoBehaviourPunCallbacks
{
    GameObject[] players;
    public Text nomeJogador;
    public static bool vitoriaAlcancada = false;
    string nickname;
    public Canvas vitoria;
    public Text text_final;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //PhotonView photonView = PhotonView.Get(this);
        //photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
        //photonView.RPC("CanvasFinal", RpcTarget.All, "jup", "and jup.");
    }

    //[PunRPC]
    //void ChatMessage(string a, string b, PhotonMessageInfo info)
    //{
    //   // Debug.Log(string.Format("ChatMessage {0} {1}", a, b));
    //    Debug.LogFormat("Info: {0} {1} {2}", info.Sender, info.photonView, info.SentServerTime);
    //}

    //[PunRPC]
    //public void CanvasFinal(string a, string b, PhotonMessageInfo info)
    //{
    //    //vitoria.enabled = true;
    //    text_final.text = info.Sender.ToString();
    //}


}
