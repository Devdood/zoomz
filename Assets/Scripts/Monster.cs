using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    private Vector3 startPosition;
    private Vector3 destination;
    private bool destinationChosen = false;

    [SerializeField]
    private GameObject hitParticleEffect;

    [SerializeField]
    private float seekRadius = 10;

    protected Character target;

    protected override void Awake()
    {
        base.Awake();

        startPosition = transform.position;
        StartCoroutine(StartRoaming());
        StartCoroutine(SeekForTarget());
    }
    
    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            UpdateRoamingState();
        }
        else
        {
            UpdateTargetState();
        }
    }

    private IEnumerator SeekForTarget()
    {
        while (true)
        {
            if (target == null)
            {
                yield return new WaitForSeconds(0.35f);
                SeekForPlayer();
            }
            else
            {
                yield return new WaitUntil(() => target == null);
            }
        }
    }

    private void SeekForPlayer()
    {
        Player p = GameUtils.GetNearbyByType<Player>(transform.position, seekRadius);

        if(p != null)
        {
            SetTarget(p);
        }
    }
    
    public void InformNearbyEnemies(Character target)
    {
        List<Monster> monsters = GameUtils.GetNearbyObjectsByType<Monster>(transform.position, seekRadius, false, this);

        foreach (var monster in monsters)
        {
            if (monster.target == null)
            {
                monster.SetTarget(target);
            }
        }
    }

    private void SetTarget(Character newTarget)
    {
        this.target = newTarget;

        if(newTarget != null)
        {
            InformNearbyEnemies(newTarget);
        }
    }

    private IEnumerator StartRoaming()
    {
        while(true)
        {
            if (target == null)
            {
                float randomTime = Random.Range(2, 5);
                yield return new WaitForSeconds(randomTime);
                Vector3 destination = startPosition + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
                SetDestination(destination);
                yield return new WaitUntil(() => destinationChosen == false || target != null);
            }
            else
            {
                yield return new WaitUntil(() => target == null);
            }
        }
    }

    public override void Die(DamageInfo damageInfo)
    {
        base.Die(damageInfo);
    }

    public override void TakeDamage(DamageInfo damageInfo)
    {
        base.TakeDamage(damageInfo);

        if (hitParticleEffect != null)
        {
            VfxManager.Instance.SpawnEffect(hitParticleEffect, transform.position, 1);
        }

        SetTarget(damageInfo.Attacker);
    }

    private void UpdateTargetState()
    {
        SetDestination(target.transform.position);
        MoveToDestination(target.transform.position, 2);
    }

    private void UpdateRoamingState()
    {
        if (destinationChosen)
        {
            MoveToDestination(this.destination);
        }
    }

    private void MoveToDestination(Vector3 destination, float stopDistance = 0.1f)
    {
        float distance = Vector3.Distance(transform.position.GetFlat(), destination.GetFlat());
        if (distance > stopDistance)
        {
            Vector3 direction = destination - transform.position;
            Move(direction.normalized);
        }
        else
        {
            destinationChosen = false;
            StopMoving();
        }
    }

    private void SetDestination(Vector3 destination)
    {
        this.destination = destination;

        Vector3 direction = (destination - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        destinationChosen = true;
    }
}
