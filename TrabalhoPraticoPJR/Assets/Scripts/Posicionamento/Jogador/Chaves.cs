using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Chaves : MonoBehaviour
{
    public int numero_chaves1=0, numero_chaves2=0;
    public Text chaves, text_final, text_final1;
    Canvas vitoria, derrota, empate;
    string nickname;
    private PhotonView photonView;

    public int NumeroChaves
    {
        get { return numero_chaves1; }
        set { numero_chaves1 = value; }
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        text_final = GameObject.Find("Nome").GetComponent<Text>();
        text_final1 = GameObject.Find("Nome1").GetComponent<Text>();

        vitoria = GameObject.Find("VitoriaCanvas").GetComponent<Canvas>();
        derrota = GameObject.Find("Derrota").GetComponent<Canvas>();
        empate = GameObject.Find("Empate").GetComponent<Canvas>();


        int i = PhotonNetwork.LocalPlayer.ActorNumber;
        nickname =PhotonNetwork.PlayerList[i-1].NickName;
    }

    void Update()
    {
        chaves.text = numero_chaves1.ToString();
        
        PhotonView photonView = PhotonView.Get(this);
        if (numero_chaves1 == 5)
        {
            photonView.RPC("CanvasFinal", RpcTarget.All, "", numero_chaves1.ToString());
        }
        else
        {
            if (derrota.enabled)
            {
                text_final1.text = nickname;
            }
        }

        if (numero_chaves1 == -1)
        {
            empate.enabled = true;
        }

    }

    public string obterNickname()
    {
        return photonView.Owner.NickName;
    }

    public int ObterNumeroChaves()
    {
        return numero_chaves1;
    }

    [PunRPC]
    public void CanvasFinal(string a, string b, PhotonMessageInfo info)
    {
        if (photonView.IsMine)
        {
            vitoria.enabled = true;
            text_final.text = info.Sender.NickName;
        }
        else
        {
            derrota.enabled = true;
        }
    }

    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.tag == "Chave")
            {

                numero_chaves1++;
                Destroy(other.gameObject);
            }
        }
    }
}
