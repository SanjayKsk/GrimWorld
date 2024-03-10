using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int health;
    [HideInInspector]
    public Transform player;
    public float speed; 
    public float timeBetweenAttacks;

    public int dropChance;
    public GameObject[] droppables;
    public int damage;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            int randomChance = Random.Range(0, 101);
            if (randomChance < dropChance)
            {
                GameObject drop = droppables[Random.Range(0, droppables.Length)];
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
