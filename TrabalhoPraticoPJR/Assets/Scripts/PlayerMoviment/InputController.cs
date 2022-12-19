using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private PlayerControls _playerControls;

    void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    public Vector2 GetPlayerMoviment()
    {
        return _playerControls.Player.Moviment.ReadValue<Vector2>();
    }

    public bool GetPlayerJumpInThisFrame()
    {
        return _playerControls.Player.Jump.triggered;
    }

    public Vector2 GetPlayerLook()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }


    public bool GetPlayerSairEsc()
    {
        return _playerControls.Player.SairEsc.triggered;
    }

    public bool GetCameraZoom()
    {
        return _playerControls.Player.ZoomCamera.IsPressed();

    }


    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
