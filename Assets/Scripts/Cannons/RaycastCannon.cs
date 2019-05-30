using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCannon : Cannon
{
    [SerializeField]
    private float rayDistance = 10;

    public override void Shoot(Character shooter)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            Debug.Log(hit.collider);
            Character target = hit.collider.GetComponent<Character>();
            if (target != null)
            {
                target.TakeDamage(new DamageInfo()
                {
                    Attacker = shooter,
                    Damage = damage
                });
            }
        }
    }
}
