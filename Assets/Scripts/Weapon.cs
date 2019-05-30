using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Cannon[] cannons;

    public void Attack(Character shooter)
    {
        foreach (Cannon cannon in cannons)
        {
            cannon.Shoot(shooter);
        }
    }
}