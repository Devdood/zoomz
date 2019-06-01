using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody rigidbody;

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected float speed = 4;

    [SerializeField]
    protected float jumpSpeed = 4;

    [SerializeField]
    private int health = 3;
    
    protected Vector3 velocity;
    protected bool canAttack;
    protected float lastAttackTime = -100;
    private float lastJumpTime;

    public bool IsMoving { get; private set; }
    public bool CanAttack
    {
        get
        {
            if (Time.time < lastAttackTime + 0.2f)
            {
                return false;
            }

            return canAttack;
        }
        set
        {
            canAttack = value;
        }
    }
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public event Action<Character> OnDamage = delegate { };

    protected virtual void Awake()
    {
        CanAttack = true;
    }

    protected virtual void Update()
    {
        Vector3 vel = velocity * speed;

        if (!IsGrounded() || Time.time < lastJumpTime + 0.2f)
        {
            vel.y = rigidbody.velocity.y;
        }
        else
        {
            vel.y = 0;
        }

        rigidbody.velocity = vel;
    }

    public void Jump(float jumpSpeed)
    {
        if(!IsGrounded())
        {
            return;
        }

        lastJumpTime = Time.time;
        Vector3 actualVelocity = rigidbody.velocity;
        actualVelocity.y = jumpSpeed;

        rigidbody.velocity = actualVelocity;
    }

    public void Jump()
    {
        Jump(jumpSpeed);
    }

    public virtual void Attack()
    {
        lastAttackTime = Time.time;
        animator.SetTrigger("attack");
    }

    public virtual void TakeDamage(DamageInfo damageInfo)
    {
        Health -= damageInfo.Damage;
        OnDamage(this);

        animator.SetTrigger("damage");

        if(Health <= 0)
        {
            Die(damageInfo);
        }
    }

    public virtual void Die(DamageInfo damageInfo)
    {
        Destroy(gameObject);
    }

    public void Move(Vector3 direction)
    {
        velocity = direction;
        IsMoving = true;
        animator.SetBool("moving", true);
    }

    public void StopMoving()
    {
        IsMoving = false;
        velocity = Vector3.zero;
        animator.SetBool("moving", false);
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            return true;
        }

        return false;
    }
}
