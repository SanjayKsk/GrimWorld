using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyControl
{
    public float stoppingDist; // Distance from the player to stop

    public float attackSpeed; // Attack speed of enemy

    private float attackTime; // Time between attacks
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDist)
            {
                // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else {
                if (Time.time >= attackTime)
                {
                    // Attack the player
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    IEnumerator Attack() {
        // Damage the player
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float animationPercent = 0;
        while (animationPercent <= 1)
        {
            animationPercent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(animationPercent, 2) + animationPercent) * 4; // Parabola formula
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula); // Lerp between the original position and the target position
            yield return null;
        }

    }
}
