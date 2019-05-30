using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Transform model;

    [SerializeField]
    private Weapon weapon;

    public Transform Model { get => model; set => model = value; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
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
