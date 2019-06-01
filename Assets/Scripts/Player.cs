using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Transform model;

    [SerializeField]
    private Transform hand;


    [SerializeField]
    private Weapon weapon;

    [SerializeField]
    private List<WeaponSlot> weapons;

    public Transform Model { get => model; set => model = value; }

    protected override void Awake()
    {
        base.Awake();

        ChangeWeapons(0);
    }

    protected override void Update()
    {
        base.Update();
    }

    public WeaponSlot FindWeapon(int id)
    {
        WeaponSlot slot = weapons.Find(w => w.weaponId == id);
        return slot;
    }

    public void ChangeWeapons(byte slot)
    {
        if(slot >= weapons.Count)
        {
            Debug.Log("Wrong slot.");
            return;
        }

        if(weapon != null)
        {
            Destroy(weapon.gameObject);
        }

        Weapon baseWeapon = WeaponsManager.Instance.GetWeaponById(weapons[slot].weaponId);
        weapon = Instantiate(baseWeapon, hand.position, hand.rotation, hand);
    }

    public void GiveWeapon(int weaponId)
    {
        WeaponSlot wep = FindWeapon(weaponId);

        if(wep != null)
        {
            Debug.Log("Add ammo");
        }
        else
        {
            weapons.Add(new WeaponSlot()
            {
                weaponId = weaponId
            });
        }
    }

    public override void Attack()
    {
        if (weapon != null)
        {
            base.Attack();

            weapon.Attack(this);
        }
        else
        {
            Debug.Log("Weapon is not set. Can't shoot.");
        }
    }
}
