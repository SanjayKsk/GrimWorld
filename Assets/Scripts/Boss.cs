using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public EnemyControl[] enemies;
    public float offset;
    public int damage;
    private int halfHealth;
    private Animator anim;

    public GameObject deathEffect;

    private Slider hpBar;
    private SceneTransition sceneTransition;
    private void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        hpBar = FindObjectOfType<Slider>();
        hpBar.maxValue = health;
        hpBar.value = health;
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void TakeDamage(int damage)
   {
        health -= damage;
        hpBar.value = health;
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            hpBar.gameObject.SetActive(false);
            sceneTransition.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("enrage");
        
        }

        // Spawn a random enemy when the boss takes damage
        EnemyControl randEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randEnemy, transform.position + new Vector3(offset,offset,0), Quaternion.identity);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         other.GetComponent<Player>().TakeDamage(damage);
      }
   }
}
