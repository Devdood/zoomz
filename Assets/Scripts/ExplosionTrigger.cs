using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private int explosionRadius = 10;

    [SerializeField]
    private GameObject explosionFx;

    [SerializeField]
    private bool destroyOnTouch = false;

    public Character Owner { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if(destroyOnTouch)
        {
            Destroy(gameObject);
        }

        if(explosionFx != null)
        {
            VfxManager.Instance.SpawnEffect(explosionFx, transform.position);
        }

        List<Monster> monsters = GameUtils.GetNearbyObjectsByType<Monster>(transform.position, explosionRadius);
        foreach (var monster in monsters)
        {
            monster.TakeDamage(new DamageInfo()
            {
                Attacker = Owner,
                Damage = damage
            });
        }
    }
}
