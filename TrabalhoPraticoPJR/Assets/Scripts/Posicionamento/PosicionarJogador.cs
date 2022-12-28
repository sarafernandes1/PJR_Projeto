using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PosicionarJogador : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        PhotonNetwork.Instantiate("Player", new Vector2(Random.Range(-5, 7), 3.0f), Quaternion.identity);

    }
    void Start()
    {
       // PhotonNetwork.Instantiate("Player", new Vector2(Random.Range(-5, 7), 3.0f), Quaternion.identity);
      ///  PhotonNetwork.Instantiate("Inimigo", new Vector2(Random.Range(-8, 2), 3.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
