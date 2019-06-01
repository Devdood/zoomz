using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCannon : Cannon
{
    [SerializeField]
    private Projectile projectile;

    public override void Shoot(Character shooter)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Projectile projectileInstance = Instantiate(projectile, shootSlot.position, shootSlot.rotation);
        projectileInstance.Shoot(shooter, ray.direction);
    }
}
