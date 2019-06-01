using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private Rigidbody rigidbody;

    public Character Owner { get; set; }

    public void Shoot(Character owner, Vector3 direction)
    {
        this.Owner = owner;

        ExplosionTrigger explosion = GetComponent<ExplosionTrigger>();
        if (explosion != null)
        {
            explosion.Owner = Owner;
        }

        Vector3 dir = direction.normalized * speed;
        rigidbody.velocity = dir;
    }
}
