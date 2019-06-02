using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField]
    private int weaponId;

    [SerializeField]
    private int ammo = 5;

    public override void Pick(Player owner)
    {
        owner.GiveWeapon(weaponId, ammo);
    }
}
