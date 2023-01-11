using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Chaves : MonoBehaviour
{
    int numero_chaves;
    public Text chaves;
    Canvas vitoria;
    bool vitoria_;
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        vitoria = GameObject.Find("VitoriaCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        chaves.text = numero_chaves.ToString();
        if (numero_chaves == 5)
        {
            vitoria_ = true;
            Time.timeScale = 0.0f;
        }
    }

    public bool VitoriaJogador()
    {
        return vitoria_;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Chave") {
            numero_chaves++;
            Destroy(other.gameObject);
            }
    }
}
