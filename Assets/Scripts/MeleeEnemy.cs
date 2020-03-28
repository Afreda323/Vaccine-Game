using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance;
    Animator animator;
    float _timeBetweenAttacks;

    [HideInInspector]
    public override void Start()
    {
        base.Start();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                StopAttacking();
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else
            {
                if (Time.time > _timeBetweenAttacks)
                {
                    Attack();
                    _timeBetweenAttacks = Time.time + timeBetweenAttacks;
                }
            }
        } else
        {
            StopAttacking();
        }
    }

    void Attack()
    {
        print("YO");
        animator.SetBool("isAttacking", true);
        player.GetComponent<Player>().TakeDamage(damage);
    }

    void StopAttacking ()
    {
        if (animator.GetBool("isAttacking") == true)
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
