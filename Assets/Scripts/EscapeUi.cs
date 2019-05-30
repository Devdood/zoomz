using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeUi : Singleton<EscapeUi>
{
    [SerializeField]
    private GameObject panel;

    private void Start()
    {
        GameManager.Instance.OnPauseStateChanged += Instance_OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPauseStateChanged -= Instance_OnPauseStateChanged;
        }
    }

    private void Instance_OnPauseStateChanged(bool isPaused)
    {
        if (isPaused)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }
}
