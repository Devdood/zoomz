using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private GameObject explosionFx;

    [SerializeField]
    private bool destroyOnTouch = false;

    public Character Owner { get; set; }

    [SerializeField]
    private bool enemyTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (explosionFx != null)
        {
            VfxManager.Instance.SpawnEffect(explosionFx, transform.position);
        }

        if(enemyTrigger)
        { 
            Player player = other.GetComponent<Player>();
            DealDamageToTarget(player);
        }
        else
        {
            Monster monster = other.GetComponent<Monster>();
            DealDamageToTarget(monster);
        }
    }

    private void DealDamageToTarget(Character monster)
    {
        if(monster == null)
        {
            return;
        }

        if (destroyOnTouch)
        {
            Destroy(gameObject);
        }

        monster.TakeDamage(new DamageInfo()
        {
            Attacker = Owner,
            Damage = damage
        });
    }
}
