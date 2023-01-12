using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Chaves : MonoBehaviour
{
    public static int numero_chaves;
    public Text chaves, text_final;
    Canvas vitoria;
    bool vitoria_;
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        vitoria = GameObject.Find("VitoriaCanvas").GetComponent<Canvas>();
    }

    void Update()
    {
        chaves.text = numero_chaves.ToString();
        if (numero_chaves == 2)
        {
            vitoria_ = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chave") {
            numero_chaves++;
            Destroy(other.gameObject);
            }
    }
}
