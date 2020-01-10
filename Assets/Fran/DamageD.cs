using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageD : MonoBehaviour
{
    [SerializeField] private float bulletDamage;
    [SerializeField] private MovementPlayer health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    public void Damage()
 
    {
        health.playerHealth = health.playerHealth - bulletDamage;
        health.UpdateHealth();
        this.gameObject.SetActive(false);
    }
}
