using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : EnemyControl
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSummons; // Set a cooldown for the summoner to summon new enemies
    public EnemyControl enemyToSummon;
    private float summonTime;
    private Vector2 targetPosition;
    private Animator anim;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else 
            {
                anim.SetBool("isRunning", false);
                
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            
            }
        }
    }

    public void Summon()
    {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }
}
