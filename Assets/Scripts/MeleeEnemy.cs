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
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else
            {
                if (Time.time > _timeBetweenAttacks)
                {
                    animator.SetTrigger("attack");
                    _timeBetweenAttacks = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    public void Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);
    }

}
