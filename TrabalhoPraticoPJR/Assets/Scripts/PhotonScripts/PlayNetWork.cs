using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayNetWork : MonoBehaviour
{
    public MonoBehaviour[] scriptsIgnore;
    private PhotonView photonView;
    public GameObject[] camera;
    public Canvas playerCanvas;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach (var script in scriptsIgnore)
            {
                script.enabled = false;
               
            }

            foreach(GameObject obj in camera)
            {
                obj.SetActive(false);
            }

            playerCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
