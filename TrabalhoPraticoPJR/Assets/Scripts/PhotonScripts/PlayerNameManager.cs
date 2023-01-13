using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void Start()
    {
        //if (PlayerPrefs.HasKey("username"))
        //{
        //    usernameInput.text = PlayerPrefs.GetString("username");
        //    PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        //}
        //else
        //{
        //    string username = "Player " + Random.Range(0, 10000).ToString("0000");
        //    PhotonNetwork.NickName = username;
        //}
    }


    public void onUserNameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }

    public void LimparInputField()
    {
        usernameInput.text = "";
    }
}
