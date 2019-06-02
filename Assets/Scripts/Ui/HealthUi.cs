using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    [SerializeField]
    private Text healthText;

    private void Awake()
    {
        PlayerController.Instance.Player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(Character obj)
    {
        healthText.text = obj.Health.ToString();
    }
}
