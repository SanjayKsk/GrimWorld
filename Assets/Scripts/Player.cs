using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
   public float speed;
   public float health;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;
   private Rigidbody2D rb;
   private Animator anim;
   private Vector2 moveVelocity;

   private void Start()
   {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      moveVelocity = moveInput.normalized * speed;

      if (moveInput != Vector2.zero)
      {
         anim.SetBool("isRunning", true);
      }
      else
      {
         anim.SetBool("isRunning", false);
      }
   }

   private void FixedUpdate()
   {
      rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
   }

   public void TakeDamage(int damage)
   {
      health -= damage;
      UpdateUI((int)health);
      if (health <= 0)
      {
         Destroy(gameObject);
      }
   }

   public void ChangeWeapon (Weapon weaponToEquip)
   {
      Destroy(GameObject.FindGameObjectWithTag("Weapon"));
      Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
   }

   public void UpdateUI(int currentHealth)
   {
      for (int i = 0; i < hearts.Length; i++)
      {
         if (i < currentHealth)
         {
            hearts[i].sprite = fullHeart;
         }
         else
         {
            hearts[i].sprite = emptyHeart;
         }
      }
   }


}
