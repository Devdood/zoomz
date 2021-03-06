﻿using System.Collections;
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

    [SerializeField]
    private bool enemyTrigger = false;

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

        if (enemyTrigger)
        {
            List<Player> players = GameUtils.GetNearbyObjectsByType<Player>(transform.position, explosionRadius);
            foreach (var player in players)
            {
                DealDamageToTarget(player);
            }
        }
        else
        {
            List<Monster> monsters = GameUtils.GetNearbyObjectsByType<Monster>(transform.position, explosionRadius);
            foreach (var monster in monsters)
            {
                DealDamageToTarget(monster);
            }
        }
    }
    private void DealDamageToTarget(Character monster)
    {
        if (monster == null)
        {
            return;
        }

        monster.TakeDamage(new DamageInfo()
        {
            Attacker = Owner,
            Damage = damage
        });
    }
}
