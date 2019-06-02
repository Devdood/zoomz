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

    private WeaponSlot actualSlot;

    public Transform Model { get => model; set => model = value; }
    public WeaponSlot ActualSlot { get => actualSlot; }

    public event Action<Player, WeaponSlot> OnWeaponChanged = delegate { };
    public event Action<Player, WeaponSlot> OnShoot = delegate { };

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

        actualSlot = weapons[slot];
        OnWeaponChanged(this, ActualSlot);
    }

    public void GiveWeapon(int weaponId, int ammo)
    {
        WeaponSlot wep = FindWeapon(weaponId);
        Debug.Log(ammo);
        if(wep != null)
        {
            Debug.Log("Add ammo");
        }
        else
        {
            weapons.Add(new WeaponSlot()
            {
                weaponId = weaponId,
                ammo = ammo
            });
        }
    }

    public override void Attack()
    {
        if (weapon != null)
        {
            if (ActualSlot.ammo > 0 || ActualSlot.ammo == -1)
            {
                base.Attack();

                weapon.Attack(this);
                if (ActualSlot.ammo != -1)
                {
                    ActualSlot.ammo--;
                }
                OnShoot(this, ActualSlot);
            }
        }
        else
        {
            Debug.Log("Weapon is not set. Can't shoot.");
        }
    }
}
