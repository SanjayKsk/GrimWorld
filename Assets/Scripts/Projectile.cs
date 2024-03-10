using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;
    public GameObject burst;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(burst, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyControl>().TakeDamage(damage);
            DestroyProjectile();
        }

        if (other.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
