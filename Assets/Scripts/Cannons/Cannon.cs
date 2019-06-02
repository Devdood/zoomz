using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cannon : MonoBehaviour
{
    [SerializeField]
    protected Transform shootSlot;

    [SerializeField]
    protected int damage = 1;

    public abstract void Shoot(Character shooter, Vector3 direction);
}
