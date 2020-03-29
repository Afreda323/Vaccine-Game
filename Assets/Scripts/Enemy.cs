using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float timeBetweenAttacks;
    public GameObject spawnParticles;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawn());
    }

    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.01f);
        Particles();
    }

    void Particles()
    {
        Instantiate(spawnParticles, transform.position, transform.rotation);
    }

    private void OnDestroy()
    {
        Particles();
    }
}
