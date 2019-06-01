using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField]
    private int weaponId;

    public override void Pick(Player owner)
    {
        owner.GiveWeapon(weaponId);
    }
}
