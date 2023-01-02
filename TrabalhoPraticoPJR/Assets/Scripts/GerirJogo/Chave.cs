using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Chave : MonoBehaviour
{
    int numero_chaves = 0;
    bool jogo_acabado = false;
    public Text chaves_Text;
    public PhotonView photonView;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            chaves_Text.text = numero_chaves.ToString();
        }

        if (numero_chaves==3)
        {
            jogo_acabado = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chave")
        {
            numero_chaves++;
        }
    }
}
