using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    CircleCollider2D hitBox;
    EnemyPerception ep;
    // Start is called before the first frame update
    void Start()
    {
        ep = GetComponent<EnemyPerception>();
        rb = GetComponent<Rigidbody2D>();
        hitBox = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement if needed
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HurtBox")
        {
            //die
            hitBox.enabled = false;
            Destroy(ep);
            Destroy(this);
        }
    }
}
