using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppables : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().ChangeWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
