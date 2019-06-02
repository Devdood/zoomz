using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUi : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    void Start()
    {
        PlayerController.Instance.Player.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        try
        {
            PlayerController.Instance.Player.OnDeath += OnDeath;
        }
        catch(Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    private void OnDeath(Character obj)
    {
        panel.SetActive(true);
        PlayerController.Instance.SetLockCursorState(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
