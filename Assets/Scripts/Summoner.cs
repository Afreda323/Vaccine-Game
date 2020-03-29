using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float timeBetweenSummons;
    public GameObject minion;

    Vector2 randomPosition;
    Animator animator;
    float summonTime;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        SetNewPosition();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (player != null)
        {
            if (Vector2.Distance(transform.position, randomPosition) > .05f)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomPosition, speed * Time.deltaTime);
            } else
            {
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    animator.SetTrigger("summon");
                }
            }
        } 
    }

    private void SetNewPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        randomPosition = new Vector2(randomX, randomY);
    }

    public void Summon()
    {
        Instantiate(minion, transform.position, transform.rotation);
    }
}
