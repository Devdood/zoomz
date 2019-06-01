using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : Singleton<WeaponsManager>
{
    public List<Weapon> weapons = new List<Weapon>();

    public Weapon GetWeaponById(int id)
    {
        return weapons[id];
    }
}
