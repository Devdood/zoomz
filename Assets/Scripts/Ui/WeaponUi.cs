using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUi : MonoBehaviour
{
    [SerializeField]
    private WeaponSlot slot;

    [SerializeField]
    private Text ammoText;

    private void Start()
    {
        PlayerController.Instance.Player.OnWeaponChanged += OnWeaponChanged;
        PlayerController.Instance.Player.OnShoot += Player_OnShoot;

        RefreshAmmo(PlayerController.Instance.Player.ActualSlot);
    }

    private void Player_OnShoot(Player arg1, WeaponSlot weaponSlot)
    {
        RefreshAmmo(weaponSlot);
    }

    private void OnWeaponChanged(Player player, WeaponSlot weaponSlot)
    {
        RefreshAmmo(weaponSlot);
    }

    private void RefreshAmmo(WeaponSlot weaponSlot)
    {
        if (weaponSlot.ammo == -1)
        {
            ammoText.text = "∞";
        }
        else
        {
            ammoText.text = weaponSlot.ammo.ToString();
        }
    }
}
