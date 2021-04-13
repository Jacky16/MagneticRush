using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] float velocity;
    private Rigidbody2D prb2d;
    // Start is called before the first frame update
    void Start()
    {
        prb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        prb2d.velocity = transform.up * velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Waypoint")
        {
            velocity = -velocity;
        }
    }
}
