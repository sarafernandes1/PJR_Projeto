using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class GerirTempoJogadores : MonoBehaviour
{
    public float tempoInicial ;
    public bool timerAtivo = false;
    public Text tempoText;
    GameObject[] players;
    bool vitoriaAlcancada = false;

    private void Start()
    {
        timerAtivo = true;
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if (timerAtivo)
        {
            if (tempoInicial > 0)
            {
                tempoInicial -= Time.deltaTime;
                DisplayTime(tempoInicial);
            }
            else
            {
                tempoInicial = 0;
                timerAtivo = false;
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].GetComponent<Chaves>().NumeroChaves = (-1);
                }
            }
        }

       
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        tempoText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
