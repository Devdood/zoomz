using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool Paused { get; set; }

    public event Action<bool> OnPauseStateChanged = delegate { };

    public void SetPauseState(bool paused)
    {
        Paused = paused;
        Time.timeScale = paused ? 0 : 1;
        OnPauseStateChanged(paused);
    }
}
