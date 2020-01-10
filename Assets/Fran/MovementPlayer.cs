using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    float health;
    public float maxHealth = 100f;

    [SerializeField] private Text healthText;

    public void Start()
    {
        health = maxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = "Health: " + (int)(health);
    }

   void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void Damage(float damage)
    {
        health = Mathf.Max(0, health - damage);
        UpdateHealth();
    }
}
