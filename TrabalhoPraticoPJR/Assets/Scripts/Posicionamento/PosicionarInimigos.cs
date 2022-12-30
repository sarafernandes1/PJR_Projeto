using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PosicionarInimigos : MonoBehaviour
{
    public Vector2[] max;

    void Start()
    {
        int i = PhotonNetwork.LocalPlayer.ActorNumber;

        PhotonNetwork.Instantiate("Inimigo", new Vector2(Random.Range(max[i - 1].x, max[i - 1].y), 3.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
