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

    /*override the Start method from the EnemyControl class to set the target position to a random position within the specified range, we do this to make the 
    summoner choose a random spot to summon from.
    */
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
        // Check if player is not null to avoid moving the summoner when the player is dead
        if (player != null)
        {
            // Check if the summoner is close to its chosen target position on the map
            if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else 
            {
                anim.SetBool("isRunning", false);
                
                /* Time.time is used to check the current time in seconds, if the current time is greater than or equal to the summonTime, 
                set the summonTime to the current time plus the timeBetweenSummons, and then trigger the summon animation. */
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
