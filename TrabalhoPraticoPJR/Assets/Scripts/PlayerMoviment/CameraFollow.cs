using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    Transform maincamera;
    public InputController inputController;

    void Start()
    {
        maincamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        inputController = GameObject.Find("InputController").GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += 5.0f * new Vector3(-
        inputController.GetPlayerLook().y, inputController.GetPlayerLook().x, 0);

    }
}
