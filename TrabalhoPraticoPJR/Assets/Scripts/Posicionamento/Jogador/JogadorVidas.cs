using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class JogadorVidas : MonoBehaviour
{
    public int vidas = 5;
    Vector3 posicaoInicial;
    public Text numero_vidas;
    GameObject posicionar;

    void Start()
    {
        posicaoInicial = transform.position;
        posicionar = GameObject.Find("Posicionar1");
    }

    // Update is called once per frame
    void Update()
    {
        numero_vidas.text = vidas.ToString();
        if (vidas <= 0)
        {
            transform.position = posicionar.GetComponent<Posicionar>().JogadorSpawn();
            vidas = 5;
        }
    }

    public  void TirarVida()
    {
        vidas -= 1;
    }

}
