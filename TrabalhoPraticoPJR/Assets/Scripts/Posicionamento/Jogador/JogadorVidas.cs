using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.AI;

public class JogadorVidas : MonoBehaviour
{
    public int vidas = 5;
    Vector3 posicaoInicial;
    public Text numero_vidas;
    GameObject posicionar;
    NavMeshAgent agent;
    public RawImage[] vidas_imagem;
    int i = 0;

    void Start()
    {
        posicaoInicial = transform.position;
        posicionar = GameObject.Find("Posicionar1");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        numero_vidas.text = vidas.ToString();
        if (vidas <= 0)
        {
            // transform.position = posicionar.GetComponent<Posicionar>().JogadorSpawn();
            for (int j = 0; j < vidas_imagem.Length; j++) vidas_imagem[j].enabled = true;
            vidas = 4;
            i = 0;
        }
    }

    public void TirarVida()
    {
        vidas -= 1;
       if(i<vidas_imagem.Length) vidas_imagem[i].enabled = false;
        i++;
    }

}
