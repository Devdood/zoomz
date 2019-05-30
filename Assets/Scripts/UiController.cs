using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : Singleton<UiController>
{
    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(!panel.activeInHierarchy);
    }
}
