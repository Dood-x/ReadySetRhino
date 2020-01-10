using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 5f;
    public float moveSpeed = 7f;

    Rigidbody2D rb;
    GameObject player;
    Vector2 moveDirection;

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 40f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Hit!");

            MovementPlayer mp = player.GetComponent<MovementPlayer>();
            if (mp)
            {
                mp.Damage(bulletDamage);
            }

            Destroy(gameObject);

        }
    }
}
