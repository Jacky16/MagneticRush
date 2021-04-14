using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPole : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float force;
    [SerializeField] float speed;
    bool canMove;
    [SerializeField] GameObject prefabParticleDestroy;
    Rigidbody2D rb2dPlayer;
    Rigidbody2D rb2d;
    bool playerInRadius;
    Vector2 dir;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2dPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerInRadius = Vector2.Distance(transform.position, rb2dPlayer.position) <= radius;
    }
    private void FixedUpdate()
    {
        if(!playerInRadius && canMove)
        rb2d.AddForce(Vector2.left * speed);
        if (playerInRadius)
        {
            ////Mover al player
            dir = (transform.position - rb2dPlayer.transform.position).normalized;
            rb2dPlayer.AddForceAtPosition(dir * force, rb2dPlayer.position, ForceMode2D.Force);

            //Mover el enemigo hacia al player
            Vector2 dirToPlayer = (rb2dPlayer.transform.position - transform.position).normalized;
            rb2d.AddForce(dirToPlayer * force, ForceMode2D.Force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Reboot.singletone.RebootScene();
        }
        if (!collision.collider.CompareTag("Particle"))
        {
            Instantiate(prefabParticleDestroy, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Active"))
        {
            canMove = true;
        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
