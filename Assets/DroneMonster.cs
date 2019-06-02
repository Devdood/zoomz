using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMonster : Monster
{
    [SerializeField]
    private Cannon[] cannons;

    public override void Attack()
    {
        animator.SetTrigger("Attack");
        lastAttackTime = Time.time;

        foreach (var cannon in cannons)
        {
            cannon.Shoot(this, (target.transform.position - transform.position).normalized);
        }
    }
}
