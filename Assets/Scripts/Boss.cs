using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public Transform shotPoint;
    public GameObject projectile;
    public GameObject projectile2;

    Animator animator;
    Vector2 randomPosition;
    float _timeBetweenAttacks;

    [HideInInspector]
    public override void Start()
    {
        base.Start();
        animator = gameObject.GetComponent<Animator>();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        randomPosition = new Vector2(randomX, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, randomPosition) > .05f)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
            }
            else
            {
                if (health > 5 && Time.time > _timeBetweenAttacks)
                {
                    _timeBetweenAttacks = timeBetweenAttacks + Time.time;
                    animator.SetTrigger("attack");
                } else if (health <= 5)
                {
                    animator.SetTrigger("attack2");
                }
            }
        }
    }

    public void Attack()
    {
        Vector2 position = player.position - shotPoint.position;
        float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
    }

    public void Attack2()
    {
        Vector2 position = player.position - shotPoint.position;
        float angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(projectile2, shotPoint.position, shotPoint.rotation);
    }

}
