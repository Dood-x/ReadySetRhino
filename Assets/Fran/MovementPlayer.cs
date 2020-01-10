using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Animator anim;

    Transform hurtBox;

    float health;
    public float maxHealth = 100f;

    GameObject[] enemies;

    public int enemiesKilled = 0;

    Vector3 hutrboxRight = new Vector3(0.225f, 0.069f, 0f);
    Vector3 hurtboxLeft = new Vector3(-0.225f, 0.069f, 0f);
    Vector3 hurtboxUp = new Vector3(0, 0, 0f);
    Vector3 hurtboxDown = new Vector3(0, 0, 0f);

    [SerializeField] private Text healthText;
    [SerializeField] private Text winText;
    int numEnemies = 0;

    public void Start()
    {
        health = maxHealth;
        UpdateHealth();
        anim = GetComponent<Animator>();
        anim.SetFloat("MoveX", 1.0f);
        hurtBox = GetComponentInChildren<Transform>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = enemies.Length;
    }

    public void UpdateHealth()
    {
        healthText.text = "Health: " + (int)(health);

    }

   void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);

        //if(movement.x > 0.5 )
        //{
        //    hurtBox.localPosition = hutrboxRight;
        //}
        //if (movement.x < -0.5)
        //    hurtBox.localPosition = hurtboxLeft;
        //if(movement.y > 0.5)
        //{
        //    hurtBox.localPosition = hurtboxUp;
        //}
        //if (movement.y < -0.5)
        //{
        //    hurtBox.localPosition = hurtboxDown;
        //}
       
        if (enemiesKilled == numEnemies)
            winText.enabled = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void Damage(float damage)
    {
        health = Mathf.Max(0.0f, health - damage);
        if(health <= 0.0f)
        {
            //Destroy(this.gameObject);
            Application.Quit();
        }
        UpdateHealth();
    }
}
