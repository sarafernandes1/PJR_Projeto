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

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
     

    }


  
}
