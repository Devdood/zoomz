using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private ViewController viewController;

    private float x, y;

    public Player Player { get => player; set => player = value; }

    private void Start()
    {
        GameManager.Instance.OnPauseStateChanged += OnPauseStateChanged;

        SetLockCursorState(true);
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
        }
    }

    private void Update()
    {
        UpdateInput();
    }

    private void OnPauseStateChanged(bool isPaused)
    {
        SetLockCursorState(!isPaused);
    }

    private void SetLockCursorState(bool isLocked)
    {
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isLocked;
    }

    private void UpdateInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetPauseState(!GameManager.Instance.Paused);
        }

        if(GameManager.Instance.Paused)
        {
            if(Player.IsMoving)
            {
                Player.StopMoving();
            }
            return;
        }

        viewController.ControlCamera();

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction != Vector3.zero)
        {
            Player.Move(Player.transform.rotation * direction);
        }
        else
        {
            Player.StopMoving();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.ChangeWeapons(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.ChangeWeapons(1);
        }

        if (Input.GetButton("Jump"))
        {
            Player.Jump();
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Player.CanAttack)
            {
                Player.Attack();
            }
        }
    }
}
