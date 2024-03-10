using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerBullet : MonoBehaviour
{
    private Player player;
    private Vector2 target;
    public float speed;
    public int damage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
