using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPerception : MonoBehaviour
{
    public float sightDistance = 0.5f;
    public float lostPlayerTime = 4.0f;
    GameObject player;
    EnemyShooting enemyShooting;
    public bool lostPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyShooting = GetComponent<EnemyShooting>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        bool playerSeenLastFrame = false;
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir);
        if (enemyShooting == true)
            playerSeenLastFrame = true;

        enemyShooting.enabled = false;
        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Player")
            {
                // within reach?
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                if(distance <= sightDistance)
                {
                    enemyShooting.enabled = true;
                    Debug.Log("PlayerSighted");
                }
            }
        }


        if (enemyShooting == false && playerSeenLastFrame == true)
        {
            StopCoroutine("LostPlayerCountdown");
            StartCoroutine("LostPlayerCountdown");
            Debug.Log("PlayerLost");

        }
    }

    IEnumerator LostPlayerCountdown()
    {
        lostPlayer = true;
        yield return new WaitForSeconds(lostPlayerTime);
        lostPlayer = false;
    }
}
